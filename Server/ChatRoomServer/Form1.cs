using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChatRoomServer
{

    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            UserDict = new Dictionary<string, ClientInfo>();
            RoomDict = new Dictionary<string, ChatRoom>();
        }

        X509Certificate serverCertificate;
        private delegate void delUpdateUI(string sMessage);
        private delegate void delWriteTextBox(TextBox t, string s);

        TcpListener m_server;
        Thread m_thrListening;
        Dictionary<string, ClientInfo> UserDict;
        Dictionary<string, ChatRoom> RoomDict;
        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int nPort = Convert.ToInt32(txtPort.Text);
                IPAddress localAddr = IPAddress.Parse(txtIP.Text);

                m_server = new TcpListener(localAddr, nPort);
                m_server.Start();
                m_thrListening = new Thread(Listening);
                m_thrListening.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
        }

        private void Listening()
        {
            try
            {
                while (true)
                {
                    UpdateStatus("Waiting for connection...");
                    TcpClient client = m_server.AcceptTcpClient();
                    UpdateStatus("Connect to client!");
                    Thread cThread = new Thread(() => ClientThread(client));
                    cThread.Start();
                    Thread.Sleep(1000);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
        }

        private void ClientThread(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            // ssl 
            X509Certificate serverCertificate = null;

            try
            {
                serverCertificate = new X509Certificate2("../../../../../certificate.pfx", "1234");
            }
            catch (Exception e)
            {
                UpdateStatus(e.ToString());
                Thread.Sleep(20000);
            }
            SslStream sslStream = new SslStream(stream, false);

            try
            {
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);
            }
            catch (Exception e)
            {
                WriteSomething(InfoBox, e.ToString());
                UpdateStatus(e.ToString());
                Thread.Sleep(20000);
            }

            byte[] btDatas = new byte[512];
            string sData;
            WriteSomething(InfoBox, "InClientThread");
            string clinetName = "";
            string roomName = "";
            while (true)
            {
                try
                {
                    int len = sslStream.Read(btDatas, 0, btDatas.Length);
                    sData = System.Text.Encoding.ASCII.GetString(btDatas, 0, len);
                    WriteSomething(InfoBox, sData);
                    string action;
                    action = sData.Substring(0, 5);
                    string remain = sData.Substring(5);
                    string[] words = remain.Split(" ");
                    byte[] messByte;
                    switch (action)
                    {
                        case "[reg]":
                            // do user registeration.
                            if (UserDict.ContainsKey(words[0]))
                            {
                                byte[] result = System.Text.Encoding.ASCII.GetBytes("register failure: The user name is already in use.");
                                stream.Write(result);
                            }
                            else
                            {
                                ClientInfo info = new ClientInfo();
                                info.password = words[1];
                                UserDict.Add(words[0], info);
                                info.name = words[0];
                                info.stream = stream;
                                info.sslStream = sslStream;
                                byte[] result = System.Text.Encoding.ASCII.GetBytes("register successfully");
                                sslStream.Write(result);
                            }
                            break;
                        case "[log]":
                            // authenticate the user
                            if (UserDict.ContainsKey(words[0]))
                            {
                                string name = UserDict[words[0]].password;
                                if (String.Compare(name, words[1]) == 0)
                                {
                                    // authenticate success
                                    byte[] result = System.Text.Encoding.ASCII.GetBytes("log in success");
                                    UserDict[words[0]].LoggedIn = true;
                                    clinetName = words[0];
                                    sslStream.Write(result);
                                }
                                else
                                {
                                    byte[] result = System.Text.Encoding.ASCII.GetBytes("Wrong password");
                                    sslStream.Write(result);
                                }
                            }
                            else
                            {
                                byte[] result = System.Text.Encoding.ASCII.GetBytes("Wrong password");
                                sslStream.Write(result);
                            }
                            break;
                        case "[ent]":
                            roomName = words[0];
                            if (RoomDict.ContainsKey(roomName))
                            {
                                // push user into the room list
                                RoomDict[roomName].Users.Add(clinetName);
                                byte[] result = System.Text.Encoding.ASCII.GetBytes("[Success] Room exist, come into the room.");
                                sslStream.Write(result);
                                UserDict[clinetName].roomName = roomName;
                            }
                            else
                            {
                                // create the chat room
                                ChatRoom room = new ChatRoom();
                                room.roomName = roomName;
                                if (String.Compare(clinetName, "") != 0)
                                {
                                    room.Users.Add(clinetName);
                                }
                                else
                                {
                                    // error, should not happen 
                                }
                                RoomDict.Add(roomName, room);
                                byte[] result = System.Text.Encoding.ASCII.GetBytes("[Success] Room not exist, create one.");
                                sslStream.Write(result);
                                WriteSomething(InfoBox, "stream write");
                                UserDict[clinetName].roomName = roomName;
                            }
                            break;
                        case "[sen]":
                            // find the chat room
                            string rName = UserDict[clinetName].roomName;
                            string message = "";
                            message += "[info]";
                            message += clinetName;
                            message += "(Me):";
                            message += remain;
                            message += Environment.NewLine;
                            messByte = System.Text.Encoding.ASCII.GetBytes(message);
                            sslStream.Write(messByte);
                            // Write to all member in the caht room.
                            foreach (string s in RoomDict[rName].Users)
                            {
                                if (String.Compare(s, clinetName) != 0)
                                {
                                    string mess = "";
                                    mess += "[info]";
                                    mess += clinetName;
                                    mess += ":";
                                    mess += remain;
                                    mess += Environment.NewLine;
                                    byte[] messBy = System.Text.Encoding.ASCII.GetBytes(mess);
                                    UserDict[s].sslStream.Write(messBy);
                                }
                            }
                            break;
                        case "[lar]":
                            string allroom = "";
                            foreach (var item in RoomDict)
                            {
                                allroom += item.Key;
                                allroom += ", ";
                            }
                            if (allroom.Length == 0)
                            {
                                allroom += "no room!";
                            }
                            messByte = System.Text.Encoding.ASCII.GetBytes(allroom);
                            sslStream.Write(messByte);
                            break;

                        case "[lur]":
                            string alluser = "[user]";
                            WriteSomething(InfoBox, roomName);
                            foreach (string s in RoomDict[roomName].Users)
                            {
                                alluser += s;
                                alluser += ", ";
                            }
                            messByte = System.Text.Encoding.ASCII.GetBytes(alluser);
                            sslStream.Write(messByte);
                            break;
                        case "[exi]":
                            RoomDict[roomName].Users.Remove(clinetName);
                            roomName = "";
                            UserDict[clinetName].roomName = "";
                            break;
                        case "[out]":
                            UserDict[clinetName].LoggedIn = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    UpdateStatus("read exception:" + e.Message);
                    client.Close();
                    Thread.Sleep(5000);
                    break;
                }
            }
        }

        private void UpdateStatus(string sStatus)
        {
            if (this.InvokeRequired)
            {
                delUpdateUI del = new delUpdateUI(UpdateStatus);
                this.Invoke(del, sStatus);
            }
            else
            {
                StatusLab.Text = sStatus;
            }
        }

        private void WriteSomething(TextBox t, string s)
        {
            if (this.InvokeRequired)
            {
                delWriteTextBox del = new delWriteTextBox(WriteSomething);
                this.Invoke(del, t, s);
            }
            else
            {
                t.Text = s;
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            m_server.Dispose();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            // List all the user in the system
            string allUser = "";
            foreach (var item in UserDict)
            {
                if (item.Value.LoggedIn == false)
                {
                    continue;
                }
                allUser += "User: ";
                allUser += item.Key;
                if (item.Value.roomName.Length > 0)
                {
                    allUser += "  in the room [";
                    allUser += item.Value.roomName;
                    allUser += "]";
                }
                allUser += Environment.NewLine;
            }
            WriteSomething(InfoBox, allUser);
        }
    }
}

class ClientInfo
{
    public string name = "";
    public string password = "";
    public bool LoggedIn = false;
    public string roomName = "";
    public NetworkStream stream;
    public SslStream sslStream;
}

class ChatRoom
{
    public string roomName = "";
    public List<string> Users;
    public ChatRoom()
    {
        Users = new List<string>();
    }
}
