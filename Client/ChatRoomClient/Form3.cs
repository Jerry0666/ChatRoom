using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoomClient
{

    public partial class ChatRoom : Form
    {
        public SslStream stream;
        public string RoomName;
        public bool close;
        public string name;

        private delegate void delUpdateUI(string sMessage);
        public ChatRoom(SslStream s,string name)
        {
            InitializeComponent();
            // start the listen thread
            this.stream = s;
            this.name = name;
            UserName.Text = name;
            close = false;
            Thread listen = new Thread(() => LogChatRoomMessage());
            listen.Start();
        }



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

            if (sendBox.Text.Length > 0)
            {
                String SendStr = "[sen]";
                SendStr += sendBox.Text;
                byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
                stream.Write(btData);
                sendBox.Text = "";
            }
        }

        private void LogChatRoomMessage()
        {
            while (true)
            {
                byte[] btDatas = new byte[512];
                stream.ReadTimeout = 500;
                int len = 0;
                try
                {
                    len = stream.Read(btDatas, 0, btDatas.Length);
                }
                catch (Exception e)
                {
                    if (close == true)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                string sData;
                sData = System.Text.Encoding.ASCII.GetString(btDatas, 0, len);
                string action = sData.Substring(0, 6);
                sData = sData.Substring(6);
                switch (action)
                {
                    case "[info]":
                        updateMessage(sData);
                        break;
                    case "[user]":
                        ListUser(sData);
                        break;
                    case "[psen]":
                        updatePMessage(sData);
                        break;

                }
            }
        }

        private void updateMessage(string message)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(updateMessage);
                this.Invoke(del, message);
            }
            else
            {
                MessageWindow.Text += message;
            }
        }

        private void ListUser(string message)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(ListUser);
                this.Invoke(del, message);
            }
            else
            {
                userlabel.Text = "Users: ";
                userlabel.Text += message;
            }
        }

        private void updatePMessage(string message)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(updatePMessage);
                this.Invoke(del, message);
            }
            else
            {
                PMessage.Text += message;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnListUsers_Click(object sender, EventArgs e)
        {
            String SendStr = "[lur]";
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);

        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            string SendStr = "[exi]";
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);
            close = true;
            Thread.Sleep(1000);
            Close();
            this.Dispose();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Psend_Click(object sender, EventArgs e)
        {
            string SendStr = "[pse]";
            SendStr += PName.Text;
            SendStr += " ";
            SendStr += singleMessage.Text;
            ListUser(SendStr);
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);


        }
    }
}
