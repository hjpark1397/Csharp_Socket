namespace FileGUITCP
{
    partial class FileClient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFileSrc = new System.Windows.Forms.TextBox();
            this.btnFileSend = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(357, 28);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect.TabIndex = 0;
            this.btnFileSelect.Text = "파일 선택";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(24, 25);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(33, 12);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "파일 ";
            // 
            // txtFileSrc
            // 
            this.txtFileSrc.Location = new System.Drawing.Point(63, 25);
            this.txtFileSrc.Name = "txtFileSrc";
            this.txtFileSrc.Size = new System.Drawing.Size(288, 21);
            this.txtFileSrc.TabIndex = 4;
            // 
            // btnFileSend
            // 
            this.btnFileSend.Location = new System.Drawing.Point(12, 75);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(75, 23);
            this.btnFileSend.TabIndex = 14;
            this.btnFileSend.Text = "파일 전송";
            this.btnFileSend.UseVisualStyleBackColor = true;
            this.btnFileSend.Click += new System.EventHandler(this.btnFileSend_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 77);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(167, 21);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // FileClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 144);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnFileSend);
            this.Controls.Add(this.txtFileSrc);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnFileSelect);
            this.Name = "FileClient";
            this.Text = "FileClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFileSrc;
        private System.Windows.Forms.Button btnFileSend;
        private System.Windows.Forms.TextBox txtAddress;
    }
}

