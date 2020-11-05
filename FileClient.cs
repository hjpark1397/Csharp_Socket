using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace FileGUITCP
{
    public partial class FileClient : Form
    {
        Socket mainSock, fileSock;
        IPAddress thisAddress = IPAddress.Parse("127.0.0.1");
        int port = 15000;
        int fPort= 15001;
        string FileSrc = "";
        FileInfo FileInfo = null;
        static ManualResetEvent manualEvent = new ManualResetEvent(false);
        public FileClient()
        {
            InitializeComponent();
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            fileSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileSrc = ofd.FileName;
                    txtFileSrc.Text = FileSrc;
                    FileInfo = new FileInfo(FileSrc);
                }
            }

        }


        private void btnFileSend_Click(object sender, EventArgs e)
        {
            if (mainSock.IsBound) return; //이미 연결
   
            if (FileInfo == null) return;

            // 서버에 연결
            try
            {
                mainSock.Connect(thisAddress, port);
                Console.WriteLine( "서버 연결:");
                string fileLength = FileInfo.Length.ToString();
                string fileName = FileInfo.Name;

                byte[] bDts = Encoding.UTF8.GetBytes(
                   fileName + ":" + fileLength + ":");

                // 서버에 전송한다.
                mainSock.Send(bDts);
                Console.WriteLine("파일 정보 송신");
                byte[] bDtsRx = new byte[4096];
                mainSock.BeginReceive(bDtsRx, 0, 4096, SocketFlags.None, DataReceived, bDtsRx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("연결에 실패했습니다!\n오류 내용: {0}",  ex.Message);
                return;
            }
            Thread th = new Thread(FileTXClient);
            th.Start();


        }

        void FileTXClient()
        {
            try
            {
                fileSock.Connect(thisAddress, fPort);
                Console.WriteLine("file서버 연결:");
            }
            catch (Exception ex)
            {
                Console.WriteLine("file server 연결에 실패했습니다!\n오류 내용: {0}", ex.Message);
                return;
            }

            manualEvent.WaitOne();

            //FileInfo = new FileInfo(@"C:\Welcome to Show.show");
            long fLen = FileInfo.Length;
            string fileName = FileInfo.FullName;
            byte[] bDts = new byte[4096];
            Console.WriteLine(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                if (!mainSock.IsBound) return;
                int received = 0;
                Console.WriteLine("파일을 송신 시작");
                while (received < fLen)
                {
                    received += fs.Read(bDts, 0, bDts.Length);
                    fileSock.Send(bDts, 0, bDts.Length, 0);
                    Array.Clear(bDts, 0, bDts.Length);
                }
                fs.Close();
                Console.WriteLine("파일을 수신 완료");
            }
        }
        void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            byte[] bDts = (byte []) ar.AsyncState;

            // 데이터 수신을 끝낸다.
            int received = mainSock.EndReceive(ar);

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            if (received <= 0)
            {
                mainSock.Disconnect(false);
                mainSock.Close();
                return;
            }
            string text = Encoding.UTF8.GetString(bDts, 0, received).Trim();
            string [] token = text.Split(':');
            Console.WriteLine(text + ":");
           if (token[0].Equals("OK"))
                     manualEvent.Set();

        }
    }
}
