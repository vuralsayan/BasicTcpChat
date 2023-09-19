namespace TCPClient
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            TxtIP = new System.Windows.Forms.TextBox();
            BtnConnect = new System.Windows.Forms.Button();
            TxtInfo = new System.Windows.Forms.TextBox();
            TxtMessage = new System.Windows.Forms.TextBox();
            BtnSend = new System.Windows.Forms.Button();
            LstCllientIP = new System.Windows.Forms.ListBox();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(239, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 30);
            label1.TabIndex = 0;
            label1.Text = "Server:";
            // 
            // TxtIP
            // 
            TxtIP.Location = new System.Drawing.Point(313, 13);
            TxtIP.Margin = new System.Windows.Forms.Padding(4);
            TxtIP.Name = "TxtIP";
            TxtIP.Size = new System.Drawing.Size(736, 36);
            TxtIP.TabIndex = 1;
            // 
            // BtnConnect
            // 
            BtnConnect.Location = new System.Drawing.Point(897, 456);
            BtnConnect.Margin = new System.Windows.Forms.Padding(4);
            BtnConnect.Name = "BtnConnect";
            BtnConnect.Size = new System.Drawing.Size(152, 50);
            BtnConnect.TabIndex = 2;
            BtnConnect.Text = "Connect";
            BtnConnect.UseVisualStyleBackColor = true;
            BtnConnect.Click += BtnConnect_Click;
            // 
            // TxtInfo
            // 
            TxtInfo.Location = new System.Drawing.Point(313, 54);
            TxtInfo.Margin = new System.Windows.Forms.Padding(4);
            TxtInfo.Multiline = true;
            TxtInfo.Name = "TxtInfo";
            TxtInfo.ReadOnly = true;
            TxtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            TxtInfo.Size = new System.Drawing.Size(736, 350);
            TxtInfo.TabIndex = 3;
            // 
            // TxtMessage
            // 
            TxtMessage.Location = new System.Drawing.Point(313, 412);
            TxtMessage.Margin = new System.Windows.Forms.Padding(4);
            TxtMessage.Name = "TxtMessage";
            TxtMessage.Size = new System.Drawing.Size(736, 36);
            TxtMessage.TabIndex = 5;
            // 
            // BtnSend
            // 
            BtnSend.Location = new System.Drawing.Point(737, 456);
            BtnSend.Margin = new System.Windows.Forms.Padding(4);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new System.Drawing.Size(152, 50);
            BtnSend.TabIndex = 6;
            BtnSend.Text = "Send";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // LstCllientIP
            // 
            LstCllientIP.FormattingEnabled = true;
            LstCllientIP.ItemHeight = 30;
            LstCllientIP.Location = new System.Drawing.Point(12, 54);
            LstCllientIP.Name = "LstCllientIP";
            LstCllientIP.Size = new System.Drawing.Size(294, 394);
            LstCllientIP.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 454);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(294, 42);
            button1.TabIndex = 8;
            button1.Text = "Private Chat";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AcceptButton = BtnSend;
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1071, 525);
            Controls.Add(button1);
            Controls.Add(LstCllientIP);
            Controls.Add(BtnSend);
            Controls.Add(TxtMessage);
            Controls.Add(TxtInfo);
            Controls.Add(BtnConnect);
            Controls.Add(TxtIP);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TCP / Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.TextBox TxtInfo;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.ListBox LstCllientIP;
        private System.Windows.Forms.Button button1;
    }
}
