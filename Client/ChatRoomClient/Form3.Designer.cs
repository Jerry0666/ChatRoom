namespace ChatRoomClient
{
    partial class ChatRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MessageWindow = new TextBox();
            sendBox = new TextBox();
            BtnSend = new Button();
            BtnLeft = new Button();
            BtnListUsers = new Button();
            userlabel = new Label();
            label1 = new Label();
            PMessage = new TextBox();
            label2 = new Label();
            PName = new TextBox();
            label3 = new Label();
            singleMessage = new TextBox();
            Psend = new Button();
            UserName = new Label();
            SuspendLayout();
            // 
            // MessageWindow
            // 
            MessageWindow.Location = new Point(73, 55);
            MessageWindow.Multiline = true;
            MessageWindow.Name = "MessageWindow";
            MessageWindow.ScrollBars = ScrollBars.Vertical;
            MessageWindow.Size = new Size(442, 349);
            MessageWindow.TabIndex = 0;
            MessageWindow.WordWrap = false;
            // 
            // sendBox
            // 
            sendBox.Location = new Point(73, 451);
            sendBox.Multiline = true;
            sendBox.Name = "sendBox";
            sendBox.Size = new Size(442, 68);
            sendBox.TabIndex = 1;
            // 
            // BtnSend
            // 
            BtnSend.Location = new Point(12, 539);
            BtnSend.Name = "BtnSend";
            BtnSend.Size = new Size(129, 38);
            BtnSend.TabIndex = 2;
            BtnSend.Text = "Send";
            BtnSend.UseVisualStyleBackColor = true;
            BtnSend.Click += BtnSend_Click;
            // 
            // BtnLeft
            // 
            BtnLeft.Location = new Point(399, 539);
            BtnLeft.Name = "BtnLeft";
            BtnLeft.Size = new Size(182, 38);
            BtnLeft.TabIndex = 3;
            BtnLeft.Text = "Leave room";
            BtnLeft.UseVisualStyleBackColor = true;
            BtnLeft.Click += BtnLeft_Click;
            // 
            // BtnListUsers
            // 
            BtnListUsers.Location = new Point(203, 539);
            BtnListUsers.Name = "BtnListUsers";
            BtnListUsers.Size = new Size(146, 38);
            BtnListUsers.TabIndex = 4;
            BtnListUsers.Text = "List All User";
            BtnListUsers.UseVisualStyleBackColor = true;
            BtnListUsers.Click += BtnListUsers_Click;
            // 
            // userlabel
            // 
            userlabel.AutoSize = true;
            userlabel.Location = new Point(70, 592);
            userlabel.Name = "userlabel";
            userlabel.Size = new Size(69, 25);
            userlabel.TabIndex = 5;
            userlabel.Text = "Users:";
            userlabel.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(639, 41);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 6;
            label1.Text = "Private message";
            label1.Click += label1_Click_1;
            // 
            // PMessage
            // 
            PMessage.Location = new Point(639, 83);
            PMessage.Multiline = true;
            PMessage.Name = "PMessage";
            PMessage.ScrollBars = ScrollBars.Vertical;
            PMessage.Size = new Size(392, 321);
            PMessage.TabIndex = 7;
            PMessage.WordWrap = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(639, 434);
            label2.Name = "label2";
            label2.Size = new Size(42, 25);
            label2.TabIndex = 8;
            label2.Text = "To:";
            // 
            // PName
            // 
            PName.Location = new Point(706, 431);
            PName.Name = "PName";
            PName.Size = new Size(178, 33);
            PName.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(639, 485);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 10;
            label3.Text = "message:";
            // 
            // singleMessage
            // 
            singleMessage.Location = new Point(643, 524);
            singleMessage.Multiline = true;
            singleMessage.Name = "singleMessage";
            singleMessage.Size = new Size(388, 93);
            singleMessage.TabIndex = 11;
            // 
            // Psend
            // 
            Psend.Location = new Point(915, 635);
            Psend.Name = "Psend";
            Psend.Size = new Size(105, 37);
            Psend.TabIndex = 12;
            Psend.Text = "send";
            Psend.UseVisualStyleBackColor = true;
            Psend.Click += Psend_Click;
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(112, 18);
            UserName.Name = "UserName";
            UserName.Size = new Size(66, 25);
            UserName.TabIndex = 13;
            UserName.Text = "name";
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 693);
            Controls.Add(UserName);
            Controls.Add(Psend);
            Controls.Add(singleMessage);
            Controls.Add(label3);
            Controls.Add(PName);
            Controls.Add(label2);
            Controls.Add(PMessage);
            Controls.Add(label1);
            Controls.Add(userlabel);
            Controls.Add(BtnListUsers);
            Controls.Add(BtnLeft);
            Controls.Add(BtnSend);
            Controls.Add(sendBox);
            Controls.Add(MessageWindow);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "ChatRoom";
            Text = "Chat room";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MessageWindow;
        private TextBox sendBox;
        private Button BtnSend;
        private Button BtnLeft;
        private Button BtnListUsers;
        private Label userlabel;
        private Label label1;
        private TextBox PMessage;
        private Label label2;
        private TextBox PName;
        private Label label3;
        private TextBox singleMessage;
        private Button Psend;
        private Label UserName;
    }
}