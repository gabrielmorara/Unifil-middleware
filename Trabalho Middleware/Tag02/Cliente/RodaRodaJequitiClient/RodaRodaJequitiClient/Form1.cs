using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RodaRodaJequitiClient
{
    public partial class Form1 : Form
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] dataBuf = new byte[received];
            Array.Copy(receivedBuf, dataBuf, received);
            var reewbdfs = Encoding.ASCII.GetString(dataBuf);
            ProcessResponse(reewbdfs);
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
        }

        private void ProcessResponse(string reewbdfs)
        {
            var list = reewbdfs.Split(',');
            var type = list[0];
            switch (type)
            {
                case "Init":
                case "chute":
                    InitProcess(list);
                    break;
                default:
                    break;
            }
        }

        public void InitProcess(string[] list)
        {
            try
            {
                palavra01.Text = list[1].ToString();
                palavra02.Text = list[2].ToString();
                palavra03.Text = list[3].ToString();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void SendLoop()
        {
            while (true)
            {
                byte[] receivedBuf = new byte[1024];
                int rev = _clientSocket.Receive(receivedBuf);
                if (rev != 0)
                {
                    byte[] data = new byte[rev];
                    Array.Copy(receivedBuf, data, rev);
                    lb_stt.Text = ("Received: " + Encoding.ASCII.GetString(data));
                    rb_chat.AppendText("\nServer: " + Encoding.ASCII.GetString(data));
                }
                else _clientSocket.Close();
            }
        }

        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    lb_stt.Text = ("Connection attempts: " + attempts.ToString());
                }
            }
            lb_stt.Text = ("Jogando!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (_clientSocket.Connected)
            {
                var sendChar = "chute" + "," + txt_text.Text;
                byte[] buffer = Encoding.ASCII.GetBytes(sendChar);
                _clientSocket.Send(buffer);
                rb_chat.AppendText("Client: " + txt_text.Text);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            LoopConnect();
            // SendLoop();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + txName.Text);
            _clientSocket.Send(buffer);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
