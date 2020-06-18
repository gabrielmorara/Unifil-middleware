using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using RodaRodaJequitiServer.Models;

namespace RodaRodaJequitiServer
{
    public partial class Form1 : Form
    {

        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public List<SocketT2h> __ClientSockets { get; set; }
        private byte[] _buffer = new byte[1024];

        public List<String> secretlistPalavras = new List<String>();
        public List<String> listPalavrasChute = new List<String>();
        public int valorPontos = 100;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            __ClientSockets = new List<SocketT2h>();
        }
        private void frm_Server_Load(object sender, EventArgs e)
        {
            secretlistPalavras.Add("ABACAXI");
            secretlistPalavras.Add("UVA");
            secretlistPalavras.Add("TESTE");
            listPalavrasChute = GerarListpalavrasDefault();
            SetupServer();
        }
        private void SetupServer()
        {
            lb_stt.Text = "Iniciando Servidor . . .";
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            __ClientSockets.Add(new SocketT2h(socket));
            list_Client.Items.Add(socket.RemoteEndPoint.ToString());
            lb_soluong.Text = "Cliente: " + __ClientSockets.Count.ToString();
            lb_stt.Text = "Cliente connectado. . .";
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }

        private List<string> GerarListpalavrasDefault()
        {
            var list = new List<string>();
            foreach (var x in secretlistPalavras)
            {
                var tamanho = x.Length - 1;
                var newString = "";
                for (var i = 0; i <= tamanho; i++)
                {
                    newString = newString + "_";
                }

                list.Add(newString);
            }
            return list;
        }

        public string converterListToString(List<string> listPalavras)
        {
            return listPalavras[0] + "," + listPalavras[1] + "," + listPalavras[2];
        }

        public List<string> VerifyListPalavrasChute(char letra)
        {
            var list = new List<string>();
            for (var j = 0; j <= listPalavrasChute.Count - 1; j++)
            {
                var palavra = secretlistPalavras[j];
                var tamanho = palavra.Length;
                var auxRemoveChar = listPalavrasChute[j];
                var auxAddChar = "";
                for (var i = 0; i <= tamanho - 1; i++)
                {
                    if (palavra.ToArray()[i] == letra)
                    {
                        auxRemoveChar = auxRemoveChar.Remove(i, 1);
                        auxAddChar = auxRemoveChar.Insert(i, letra.ToString());
                        auxRemoveChar = auxAddChar;
                    }
                }
                var iasda = auxAddChar.Length > 0 ? auxAddChar : auxRemoveChar;
                list.Add(iasda);
            }
            return list;
        }

        // Recebe do cliente
        private void ReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected)
            {
                ProccesReceive(socket, ar);
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception)
                {
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            lb_soluong.Text = __ClientSockets.Count.ToString();
                        }
                    }
                    return;
                }
                if (received != 0)
                {
                    byte[] dataBuf = new byte[received];
                    Array.Copy(_buffer, dataBuf, received);
                    string text = Encoding.ASCII.GetString(dataBuf);
                    lb_stt.Text = "Text received: " + text;

                    string reponse = string.Empty;

                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                        {
                            rich_Text.AppendText("\n" + __ClientSockets[i]._Name + ": " + text);
                        }
                    }

                    if (text == "bye")
                    {
                        return;
                    }
                    reponse = "Server " + text;
                    Sendata(socket, reponse);
                }
                else
                {
                    for (int i = 0; i < __ClientSockets.Count; i++)
                    {
                        if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            __ClientSockets.RemoveAt(i);
                            lb_soluong.Text = __ClientSockets.Count.ToString();
                        }
                    }
                }
            }
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }

        private void ProccesReceive(Socket socket, IAsyncResult ar)
        {
            var received = socket.EndReceive(ar);
            byte[] dataBuf = new byte[received];
            Array.Copy(_buffer, dataBuf, received);
            string text = Encoding.ASCII.GetString(dataBuf);
            var type = text.Split(',');
            switch (type[0])
            {
                case "Init":
                    Iniciar(socket, type);
                    break;
                case "chute":
                    ProcessaChute(socket, type);
                    break;
                case "palavra":
                    ProcessaPalavra(socket, type);
                    break;
                default:
                    break;
            }
        }
        private void ProcessaPalavra(Socket socket, string[] type)
        {
            var player = type[1];
            var palavra = Convert.ToInt32(type[2]);
            var palavraChute = type[3];

            if (palavraChute.Equals(secretlistPalavras[palavra]))
            {
                var list = "palavra" + "," + player + "," + "acertou" + "," + palavra + "," + palavraChute + "," + 1000;
                Sendata(socket, list);
            }
            else
            {
                var list = "palavra" + "," + player + "," + "errou";
                Sendata(socket, list);
            }
        }

        public void Iniciar(Socket socket, string[] type)
        {
            Sendata(socket, "Init" + "," + converterListToString(GerarListpalavrasDefault()));
            System.Threading.Thread.Sleep(1000);
            Sendata(socket, "pontos" + "," + valorPontos);
        }

        private void ProcessaChute(Socket socket, string[] type)
        {
            var player = type[1];
            var letra = type[2];
            var pontos = type[3];

            var p1 = secretlistPalavras[0].Split(letra.ToCharArray()).Length - 1;
            var p2 = secretlistPalavras[1].Split(letra.ToCharArray()).Length - 1;
            var p3 = secretlistPalavras[2].Split(letra.ToCharArray()).Length - 1;

            var calcPontos = (p1 + p2 + p3) * Convert.ToInt32(valorPontos);
            listPalavrasChute = VerifyListPalavrasChute(letra.ToCharArray()[0]);
            Sendata(socket, "chute" + "," + converterListToString(listPalavrasChute));
            if (calcPontos > 0)
            {
                Sendata(socket, "puntuacao" + "," + player + "," + calcPontos + ",");
                valorPontos += valorPontos;
                Sendata(socket, "pontos" + "," + valorPontos + ",");
                Sendata(socket, "msg" + "," + " Jogador " + player + " acertou " + (p1 + p2 + p3) + " letra " + letra + ",");
            }
            else
            {
                Sendata(socket, "msg" + "," + " Jogador " + player + " nao acertou nenhuma letra " + letra);
            }
        }

        void Sendata(Socket socket, string noidung)
        {
            byte[] data = Encoding.ASCII.GetBytes(noidung);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list_Client.SelectedItems.Count; i++)
            {
                string t = list_Client.SelectedItems[i].ToString();
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    {
                        Sendata(__ClientSockets[j]._Socket, txt_Text.Text);
                    }
                }
            }
            rich_Text.AppendText("\nServer: " + txt_Text.Text);
        }

        private void lb_soluong_Click(object sender, EventArgs e)
        {

        }
    }
}
