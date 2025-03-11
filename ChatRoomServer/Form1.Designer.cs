namespace ChatRoomServer
{
    partial class Server
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
            label1 = new Label();
            label2 = new Label();
            txtIP = new TextBox();
            txtPort = new TextBox();
            StartBtn = new Button();
            label3 = new Label();
            InfoBox = new TextBox();
            StatusLab = new Label();
            CloseBtn = new Button();
            BtnList = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 65);
            label1.Name = "label1";
            label1.Size = new Size(36, 25);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 110);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Port:";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(201, 62);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 33);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(201, 107);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 33);
            txtPort.TabIndex = 3;
            txtPort.Text = "13000";
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(103, 163);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(97, 32);
            StartBtn.TabIndex = 4;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 219);
            label3.Name = "label3";
            label3.Size = new Size(196, 25);
            label3.TabIndex = 5;
            label3.Text = "User's information:";
            // 
            // InfoBox
            // 
            InfoBox.Location = new Point(93, 261);
            InfoBox.Multiline = true;
            InfoBox.Name = "InfoBox";
            InfoBox.ScrollBars = ScrollBars.Vertical;
            InfoBox.Size = new Size(660, 394);
            InfoBox.TabIndex = 6;
            InfoBox.WordWrap = false;
            // 
            // StatusLab
            // 
            StatusLab.AutoSize = true;
            StatusLab.ForeColor = SystemColors.ButtonShadow;
            StatusLab.Location = new Point(481, 62);
            StatusLab.Name = "StatusLab";
            StatusLab.Size = new Size(95, 25);
            StatusLab.TabIndex = 8;
            StatusLab.Text = "Stopped";
            // 
            // CloseBtn
            // 
            CloseBtn.ForeColor = Color.Red;
            CloseBtn.Location = new Point(843, 611);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(101, 44);
            CloseBtn.TabIndex = 9;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // BtnList
            // 
            BtnList.Location = new Point(256, 163);
            BtnList.Name = "BtnList";
            BtnList.Size = new Size(182, 32);
            BtnList.TabIndex = 10;
            BtnList.Text = "List all user";
            BtnList.UseVisualStyleBackColor = true;
            BtnList.Click += BtnList_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 721);
            Controls.Add(BtnList);
            Controls.Add(CloseBtn);
            Controls.Add(StatusLab);
            Controls.Add(InfoBox);
            Controls.Add(label3);
            Controls.Add(StartBtn);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIP;
        private TextBox txtPort;
        private Button StartBtn;
        private Label label3;
        private TextBox InfoBox;
        private Label StatusLab;
        private Button CloseBtn;
        private Button BtnList;
    }
}
