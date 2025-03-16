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
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 693);
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
    }
}