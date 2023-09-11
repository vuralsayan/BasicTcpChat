namespace TCPServer
{
    partial class Form1
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
            BtnStart = new System.Windows.Forms.Button();
            TxtInfo = new System.Windows.Forms.TextBox();
            TxtMessage = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            BtnSend = new System.Windows.Forms.Button();
            LstClientIP = new System.Windows.Forms.ListBox();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(28, 16);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 30);
            label1.TabIndex = 0;
            label1.Text = "Server:";
            // 
            // TxtIP
            // 
            TxtIP.Location = new System.Drawing.Point(102, 13);
            TxtIP.Margin = new System.Windows.Forms.Padding(4);
            TxtIP.Name = "TxtIP";
            TxtIP.Size = new System.Drawing.Size(736, 36);
            TxtIP.TabIndex = 1;
            // 
            // BtnStart
            // 
            BtnStart.Location = new System.Drawing.Point(687, 441);
            BtnStart.Margin = new System.Windows.Forms.Padding(4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new System.Drawing.Size(152, 50);
            BtnStart.TabIndex = 2;
            BtnStart.Text = "Start";
            BtnStart.UseVisualStyleBackColor = true;
            BtnStart.Click += BtnStart_Click;
            // 
            // TxtInfo
            // 
            TxtInfo.Location = new System.Drawing.Point(102, 54);
            TxtInfo.Margin = new System.Windows.Forms.Padding(4);
            TxtInfo.Multiline = true;
            TxtInfo.Name = "TxtInfo";
            TxtInfo.ReadOnly = true;
            TxtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            TxtInfo.Size = new System.Drawing.Size(736, 335);
            TxtInfo.TabIndex = 3;
            // 
            // TxtMessage
            // 
            TxtMessage.Location = new System.Drawing.Point(102, 400);
            TxtMessage.Margin = new System.Windows.Forms.Padding(4);
            TxtMessage.Name = "TxtMessage";
            TxtMessage.Size = new System.Drawing.Size(736, 36);
            TxtMessage.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(10, 403);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 30);
            label2.TabIndex = 4;
            label2.Text = "Message:";
            // 
            // BtnSend
            // 
            BtnSend.Location = new System.Drawing.Point(527, 441);
            BtnSend.Margin = new System.Windows.Forms.Padding(4);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new System.Drawing.Size(152, 50);
            BtnSend.TabIndex = 6;
            BtnSend.Text = "Send";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // LstClientIP
            // 
            LstClientIP.FormattingEnabled = true;
            LstClientIP.ItemHeight = 30;
            LstClientIP.Location = new System.Drawing.Point(845, 54);
            LstClientIP.Name = "LstClientIP";
            LstClientIP.Size = new System.Drawing.Size(254, 364);
            LstClientIP.TabIndex = 7;
            LstClientIP.SelectedIndexChanged += LstClientIP_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(846, 19);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(102, 30);
            label3.TabIndex = 8;
            label3.Text = "Client IP:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1111, 505);
            Controls.Add(label3);
            Controls.Add(LstClientIP);
            Controls.Add(BtnSend);
            Controls.Add(TxtMessage);
            Controls.Add(label2);
            Controls.Add(TxtInfo);
            Controls.Add(BtnStart);
            Controls.Add(TxtIP);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "TCP / Server";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox TxtInfo;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.ListBox LstClientIP;
        private System.Windows.Forms.Label label3;
    }
}
