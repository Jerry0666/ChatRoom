namespace ChatRoomClient
{
    partial class LogInForm
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
            ConnectBtn = new Button();
            ConnectStatus = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtPassword = new TextBox();
            BtnRegister = new Button();
            BtnLogIn = new Button();
            BtnLouOut = new Button();
            PromptLabel = new Label();
            BtnEnterRoom = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 56);
            label1.Name = "label1";
            label1.Size = new Size(36, 25);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 111);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Port:";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(202, 56);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 33);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(202, 108);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 33);
            txtPort.TabIndex = 3;
            txtPort.Text = "13000";
            // 
            // ConnectBtn
            // 
            ConnectBtn.Location = new Point(107, 166);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(110, 43);
            ConnectBtn.TabIndex = 4;
            ConnectBtn.Text = "Connect";
            ConnectBtn.UseVisualStyleBackColor = true;
            ConnectBtn.Click += ConnectBtn_Click;
            // 
            // ConnectStatus
            // 
            ConnectStatus.AutoSize = true;
            ConnectStatus.ForeColor = SystemColors.ButtonShadow;
            ConnectStatus.Location = new Point(91, 233);
            ConnectStatus.Name = "ConnectStatus";
            ConnectStatus.Size = new Size(144, 25);
            ConnectStatus.TabIndex = 5;
            ConnectStatus.Text = "Disconnected";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 286);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 6;
            label3.Text = "name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 346);
            label4.Name = "label4";
            label4.Size = new Size(109, 25);
            label4.TabIndex = 7;
            label4.Text = "password:";
            // 
            // txtName
            // 
            txtName.Location = new Point(271, 283);
            txtName.Name = "txtName";
            txtName.Size = new Size(163, 33);
            txtName.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(271, 346);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(163, 33);
            txtPassword.TabIndex = 9;
            // 
            // BtnRegister
            // 
            BtnRegister.Location = new Point(40, 429);
            BtnRegister.Name = "BtnRegister";
            BtnRegister.Size = new Size(122, 46);
            BtnRegister.TabIndex = 10;
            BtnRegister.Text = "Register";
            BtnRegister.UseVisualStyleBackColor = true;
            BtnRegister.Click += BtnRegister_Click;
            // 
            // BtnLogIn
            // 
            BtnLogIn.Location = new Point(190, 429);
            BtnLogIn.Name = "BtnLogIn";
            BtnLogIn.Size = new Size(122, 46);
            BtnLogIn.TabIndex = 11;
            BtnLogIn.Text = "Log in";
            BtnLogIn.UseVisualStyleBackColor = true;
            BtnLogIn.Click += BtnLogIn_Click;
            // 
            // BtnLouOut
            // 
            BtnLouOut.Location = new Point(338, 429);
            BtnLouOut.Name = "BtnLouOut";
            BtnLouOut.Size = new Size(122, 46);
            BtnLouOut.TabIndex = 12;
            BtnLouOut.Text = "Log out";
            BtnLouOut.UseVisualStyleBackColor = true;
            BtnLouOut.Click += BtnLouOut_Click;
            // 
            // PromptLabel
            // 
            PromptLabel.AutoSize = true;
            PromptLabel.ForeColor = Color.Gray;
            PromptLabel.Location = new Point(91, 515);
            PromptLabel.Name = "PromptLabel";
            PromptLabel.Size = new Size(0, 25);
            PromptLabel.TabIndex = 13;
            // 
            // BtnEnterRoom
            // 
            BtnEnterRoom.Location = new Point(40, 579);
            BtnEnterRoom.Name = "BtnEnterRoom";
            BtnEnterRoom.Size = new Size(177, 48);
            BtnEnterRoom.TabIndex = 14;
            BtnEnterRoom.Text = "Enter room";
            BtnEnterRoom.UseVisualStyleBackColor = true;
            BtnEnterRoom.Click += BtnEnterRoom_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 680);
            Controls.Add(BtnEnterRoom);
            Controls.Add(PromptLabel);
            Controls.Add(BtnLouOut);
            Controls.Add(BtnLogIn);
            Controls.Add(BtnRegister);
            Controls.Add(txtPassword);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(ConnectStatus);
            Controls.Add(ConnectBtn);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "LogInForm";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtIP;
        private TextBox txtPort;
        private Button ConnectBtn;
        private Label ConnectStatus;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtPassword;
        private Button BtnRegister;
        private Button BtnLogIn;
        private Button BtnLouOut;
        private Label PromptLabel;
        private Button BtnEnterRoom;
    }
}
