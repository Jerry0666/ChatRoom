﻿using System;
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
    public partial class Form2 : Form
    {
        public SslStream stream;
        public string name;
        public Form2(SslStream s, string name)
        {
            InitializeComponent();
            stream = s;
            byte[] btData = System.Text.Encoding.ASCII.GetBytes("form2 created!");
            stream.Write(btData);
            this.name = name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            String SendStr = "[ent]";
            SendStr += txtRoom.Text;
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);
            byte[] returnDatas = new byte[512];
            int len = stream.Read(returnDatas, 0, returnDatas.Length);
            Event.Text = "after read";
            string result = System.Text.Encoding.ASCII.GetString(returnDatas);
            //Event.Text = result;
            string prefix = result.Substring(0, 9);
            if (String.Compare(prefix, "[Success]") == 0)
            {
                // enter chat room
                Thread enterRoom = new Thread(() => createChatRoom(stream, name));
                enterRoom.Start();
                Close();
            }
        }

        private void createChatRoom(SslStream stream,string name)
        {
            ChatRoom chatRoom = new ChatRoom(stream,name);
            chatRoom.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnListRoom_Click(object sender, EventArgs e)
        {
            String SendStr = "[lar]";
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);
            byte[] returnDatas = new byte[512];
            int len = stream.Read(returnDatas, 0, returnDatas.Length);
            string result = System.Text.Encoding.ASCII.GetString(returnDatas);
            Event.Text = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            this.Dispose();
        }
    }


}

