using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RodaRodaJequitiClient
{
    public partial class Form1 : Form
    {
        private static Socket _clientSocket;
        byte[] receivedBuf = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Inicializa Socket
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Recebe dados do server
        private void ReceiveData(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] dataBuf = new byte[received];
            Array.Copy(receivedBuf, dataBuf, received);
            var response = Encoding.ASCII.GetString(dataBuf);
            ProcessaResponseServer(response);
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
        }

        // Processa metodos 
        private void ProcessaResponseServer(string response)
        {
            var list = response.Split(',');
            var type = list[0];
            switch (type)
            {
                case "Init":
                case "chute":
                    InitProcess(list);
                    break;
                case "msg":
                    ExibirMsg(list);
                    break;
                case "pontos":
                    ExibirPontos(list);
                    break;
                default:
                    break;
            }
        }

        private void ExibirPontos(string[] list)
        {
            pontos.Text = list[1];
        }

        private void ExibirMsg(string[] list)
        {
            log.Text += list[1].ToString() + " \n";
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
                    log.Text = ("Erro: " + attempts.ToString());
                }
            }
            log.Text = ("Jogando!");
        }


        // Evento de jogar
        private void btnJogar_Click(object sender, EventArgs e)
        {
            LoopConnect();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + "txtNamePlayer.Text"); // Connect Jogador
            _clientSocket.Send(buffer);
            txtNamePlayer.Text = _clientSocket.LocalEndPoint.ToString();
        }

        // Evento de enviar letra 
        private void btnLetra_Click(object sender, EventArgs e)
        {
            if (_clientSocket.Connected)
            {
                var sendChar = "chute" + "," + txtLetra.Text.ToUpper();
                byte[] buffer = Encoding.ASCII.GetBytes(sendChar);
                _clientSocket.Send(buffer);
            }
        }

        private void EnviarPalavra(string palavra, int indice)
        {
            if (_clientSocket.Connected)
            {
                var sendChar = "palavra" + "," + indice + "," + palavra.ToUpper();
                byte[] buffer = Encoding.ASCII.GetBytes(sendChar);
                _clientSocket.Send(buffer);
            }
        }

        private void btnPalavra01_Click(object sender, EventArgs e)
        {
            EnviarPalavra(textBox1.Text, 0);
        }

        private void btnPalavra02_Click(object sender, EventArgs e)
        {
            EnviarPalavra(textBox2.Text, 1);
        }

        private void btnPalavra03_Click(object sender, EventArgs e)
        {
            EnviarPalavra(textBox3.Text, 2);
        }

        // Metodos Gerados pelo form nao utilizados >>

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
