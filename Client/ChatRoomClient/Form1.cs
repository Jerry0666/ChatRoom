using Microsoft.Win32;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
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
        SslStream sslStream;

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
                // ssl stream
                sslStream = new SslStream(stream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate));
                sslStream.AuthenticateAsClient("127.0.0.1");
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.ToString());
            }
            
        }

        public static bool ValidateServerCertificate(
        object sender,
        X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
        {
            X509Certificate storedCert = new X509Certificate("../../../../../certificate.pfx","1234");
            if (certificate.Equals(storedCert))
            {
                return true;
            }
            return false;
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
                sslStream.Write(btData, 0, btData.Length);
                byte[] returnDatas = new byte[512];
                int len;
                try
                {
                    len = sslStream.Read(returnDatas, 0, returnDatas.Length);
                }
                catch (Exception ex)
                {
                    UpdateStatus(ex.ToString());
                }
                
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
                sslStream.Write(btData, 0, btData.Length);
                byte[] returnDatas = new byte[512];
                int len = sslStream.Read(returnDatas, 0, returnDatas.Length);
                string result = System.Text.Encoding.ASCII.GetString(returnDatas);
                PromptLabel.Text = result;
                if (String.Compare(result, "log in success") == 0)
                {
                    state = RegState.LoggedIn;
                    PromptLabel.Text = "log in success";
                }
            }
        }

        private void createForm2(SslStream s,string name)
        {
            Form2 f = new Form2(s, txtName.Text);
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
            Thread enter = new Thread(() => createForm2(sslStream, txtName.Text));
            enter.Start();
        }

        private void BtnLouOut_Click(object sender, EventArgs e)
        {
            String SendStr = "[out]";
            byte[] btData = System.Text.Encoding.ASCII.GetBytes(SendStr);
            sslStream.Write(btData);
            this.Dispose();
            Close();
        }
    }
}
