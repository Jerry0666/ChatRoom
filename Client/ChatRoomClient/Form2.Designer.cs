namespace ChatRoomClient
{
    partial class Form2
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
            Button BtnEnter;
            label1 = new Label();
            txtRoom = new TextBox();
            Event = new Label();
            BtnListRoom = new Button();
            button1 = new Button();
            BtnEnter = new Button();
            SuspendLayout();
            // 
            // BtnEnter
            // 
            BtnEnter.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BtnEnter.Location = new Point(47, 89);
            BtnEnter.Name = "BtnEnter";
            BtnEnter.Size = new Size(122, 40);
            BtnEnter.TabIndex = 0;
            BtnEnter.Text = "Enter";
            BtnEnter.UseVisualStyleBackColor = true;
            BtnEnter.Click += BtnEnter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(47, 39);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 1;
            label1.Text = "Room name:";
            label1.Click += label1_Click;
            // 
            // txtRoom
            // 
            txtRoom.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            txtRoom.Location = new Point(207, 36);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(129, 33);
            txtRoom.TabIndex = 2;
            // 
            // Event
            // 
            Event.AutoSize = true;
            Event.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Event.ForeColor = SystemColors.ButtonShadow;
            Event.Location = new Point(47, 146);
            Event.Name = "Event";
            Event.Size = new Size(131, 25);
            Event.TabIndex = 3;
            Event.Text = "Event result:";
            // 
            // BtnListRoom
            // 
            BtnListRoom.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            BtnListRoom.ImageAlign = ContentAlignment.BottomCenter;
            BtnListRoom.Location = new Point(207, 89);
            BtnListRoom.Name = "BtnListRoom";
            BtnListRoom.Size = new Size(161, 40);
            BtnListRoom.TabIndex = 4;
            BtnListRoom.Text = "List All Room";
            BtnListRoom.UseVisualStyleBackColor = true;
            BtnListRoom.Click += BtnListRoom_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(126, 232);
            button1.Name = "button1";
            button1.Size = new Size(118, 37);
            button1.TabIndex = 5;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 325);
            Controls.Add(button1);
            Controls.Add(BtnListRoom);
            Controls.Add(Event);
            Controls.Add(txtRoom);
            Controls.Add(label1);
            Controls.Add(BtnEnter);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRoom;
        private Label Event;
        private Button BtnListRoom;
        private Button button1;
    }
}