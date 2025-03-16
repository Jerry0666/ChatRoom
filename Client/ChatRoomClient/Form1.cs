using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

enum RegState
{
    disConnected,
    Connected,
    LoggedIn,
    enterRoom,
    
}

namespace ChatRoomClient
{
    public partial class LogInForm : Form
    {
        private TcpClient m_client;
        NetworkStream stream;
        private RegState state;

        public LogInForm()
        {
            InitializeComponent();
            state = RegState.disConnected;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Create Tcp client.
                int nPort = Convert.ToInt32(txtPort.Text);
                string remoteAddr = txtIP.Text;

                m_client = new TcpClient(remoteAddr, nPort);
                UpdateStatus("connected");
                state = RegState.Connected;
                stream = m_client.GetStream();
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException:{0}", a);
                UpdateStatus("ArgumentNullException");
            }
            catch (SocketException ex)
            {
                UpdateStatus("SocketException: " + ex.Message);
            }
        }

        private void UpdateStatus(string sStatus)
        {
            ConnectStatus.Text = sStatus;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (state == RegState.disConnected)
            {
                PromptLabel.Text = "Please connect to server first.";
            }
            if (state == RegState.Connected)
            {
                string name = txtName.Text;
                string password = txtPassword.Text;
                string sendData = "[reg]";
                sendData += name;
                sendData += " ";
                sendData += password;
                sendData += " ";
                byte[] btData = System.Text.Encoding.ASCII.GetBytes(sendData);
                stream.Write(btData, 0, btData.Length);
                byte[] returnDatas = new byte[512];
                int len = stream.Read(returnDatas, 0, returnDatas.Length);
                string result = System.Text.Encoding.ASCII.GetString(returnDatas);
                if (String.Compare(result, "register successfully") == 0)
                {
                    PromptLabel.Text = result;
                }
            }

        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            if (state == RegState.disConnected)
            {
                PromptLabel.Text = "Please connect to server first.";
            }
            if (state == RegState.Connected)
            {
                string name = txtName.Text;
                string password = txtPassword.Text;
                string sendData = "[log]";
                sendData += name;
                sendData += " ";
                sendData += password;
                sendData += " ";
                byte[] btData = System.Text.Encoding.ASCII.GetBytes(sendData);
                stream.Write(btData, 0, btData.Length);
                byte[] returnDatas = new byte[512];
                int len = stream.Read(returnDatas, 0, returnDatas.Length);
                string result = System.Text.Encoding.ASCII.GetString(returnDatas);
                PromptLabel.Text = result;
                if (String.Compare(result, "log in success") == 0)
                {
                    state = RegState.LoggedIn;
                    PromptLabel.Text = "modify state";
                }
            }
        }

        private void createForm2(NetworkStream s)
        {
            Form2 f = new Form2(s);
            f.ShowDialog();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnterRoom_Click(object sender, EventArgs e)
        {
            if (state != RegState.LoggedIn)
            {
                PromptLabel.Text = "You need to log in first.";
                return;
            }
            Thread enter = new Thread(() => createForm2(stream));
            enter.Start();
        }

        private void BtnLouOut_Click(object sender, EventArgs e)
        {
            String SendStr = "[out]";
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            stream.Write(btData);
            this.Dispose();
            Close();
        }
    }
}
