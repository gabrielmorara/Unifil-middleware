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
using RodaRodaJequitiServer.Services;

namespace RodaRodaJequitiServer
{
    public partial class Form1 : Form
    {

        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public List<SocketT2h> __ClientSockets { get; set; }
        private byte[] _buffer = new byte[1024];
        public List<String> secretlistPalavras = new List<String>();
        public List<String> listPalavrasChute = new List<String>();
        private readonly Random _random = new Random();
        public int ValorPontos = 0;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            __ClientSockets = new List<SocketT2h>();
        }

        // Gera valor dos pontos
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Inica Servidor
        private void frm_Server_Load(object sender, EventArgs e)
        {
            secretlistPalavras = Palavras.SorteiaListaPalavras();
            listPalavrasChute = GerarListpalavrasDefault();
            ValorPontos = RandomNumber(0, 1000);
            SetupServer();
        }
        private void SetupServer()
        {
            lb_stt.Text = "Iniciando Servidor . . .";
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }

        // Recebbe chamado dos Clientes
        private void AppceptCallback(IAsyncResult ar)
        {
            Socket socket = _serverSocket.EndAccept(ar);
            AddJogador(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }

        private void AddJogador(Socket socket)
        {
            var x = new SocketT2h(socket);
            if (!__ClientSockets.Contains(x))
            {
                __ClientSockets.Add(x);
                list_Client.Items.Add(socket.RemoteEndPoint.ToString());
                if (list_Client.Items.Count == 1) // Inicializa como player 1
                {
                    list_Client.SetItemChecked(0, true);
                }
            }
            lb_soluong.Text = "Clientes: " + __ClientSockets.Count.ToString();
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
                    Iniciar(socket, type);
                    break;
            }
        }

        private void ProcessaPalavra(Socket socket, string[] type)
        {
            var palavraChute = type[2];
            var indice = Convert.ToInt32(type[1]);

            if (palavraChute.Equals(secretlistPalavras[indice]))
            {
                var list = "msg" + "," + "Acetou a palavra" + palavraChute;
                SendataByClient(socket, list);
                listPalavrasChute[indice] = palavraChute;
                listPalavrasChute = VerifyListPalavrasChute('@');
                SendataAll("Init" + "," + converterListToString(listPalavrasChute));
            }
            else
            {
                var list = "palavra" + "," + "Errou a palavra";
                SendataByClient(socket, list);
            }
        }

        public void Iniciar(Socket socket, string[] type)
        {
            SendataByClient(socket, "Init" + "," + converterListToString(GerarListpalavrasDefault()));
            System.Threading.Thread.Sleep(1000);
        }

        private void ProcessaChute(Socket socket, string[] type)
        {
            if (GetJogadorAtual(socket))
            {
                var letra = type[1];

                var p1 = secretlistPalavras[0].Split(letra.ToCharArray()).Length - 1;
                var p2 = secretlistPalavras[1].Split(letra.ToCharArray()).Length - 1;
                var p3 = secretlistPalavras[2].Split(letra.ToCharArray()).Length - 1;

                var calcPontos = (p1 + p2 + p3) * Convert.ToInt32(ValorPontos);
                listPalavrasChute = VerifyListPalavrasChute(letra.ToCharArray()[0]);
                SendataAll("Init" + "," + converterListToString(listPalavrasChute));
                if (calcPontos > 0)
                {
                    SendataByClient(socket, "pontos" + "," + calcPontos + ",");
                    ValorPontos = RandomNumber(0, 1000);
                    SendataByClient(socket, "msg" + "," + " Acertou " + (p1 + p2 + p3) + " letras " + letra);
                }
                else
                {
                    SendataByClient(socket, "msg" + "," + "Nao acertou nenhuma letra " + letra);
                    ProximoJogador(socket);
                }
            }
            else
            {
                SendNaoEsuaVez(socket);
            }
        }

        private bool GetJogadorAtual(Socket socket)
        {
            var indice = list_Client.Items.IndexOf(socket.RemoteEndPoint.ToString());
            return list_Client.GetItemChecked(indice);
        }


        private void SendNaoEsuaVez(Socket socket)
        {
            SendataByClient(socket, "msg" + "," + "Aguarde sua vez para jogar");
        }

        private void ProximoJogador(Socket socket)
        {
            var nomejogador = socket.RemoteEndPoint.ToString();
            var jogadorAtual = list_Client.Items.IndexOf(nomejogador);
            var novoJogadorAtual = list_Client.Items.IndexOf(nomejogador) + 1;
            try
            {
                list_Client.SetItemChecked(novoJogadorAtual, true); // Altera apra jogador atual
                list_Client.SetItemChecked(jogadorAtual, false); // Retira flag do Jogador anterior
            }
            catch (Exception e)
            {
                novoJogadorAtual = 0;
                list_Client.SetItemChecked(novoJogadorAtual, true);
                list_Client.SetItemChecked(jogadorAtual, false);
            }
            finally
            {
                EnviarNoticacaoErro(nomejogador);
                var nomeProximoJogador = list_Client.Items[novoJogadorAtual].ToString();
                EnviarNoticicaoSuaVez(nomeProximoJogador);
            }
        }

        private void EnviarNoticicaoSuaVez(string nomeProximoJogador)
        {
            var socket = __ClientSockets.FirstOrDefault(s => s._Socket.RemoteEndPoint.ToString().Contains(nomeProximoJogador));
            SendataByClient(socket._Socket, "msg" + "," + "Sua vez de jogar!");
        }

        private void EnviarNoticacaoErro(string nomejogador)
        {
            var socket = __ClientSockets.FirstOrDefault(s => s._Socket.RemoteEndPoint.ToString().Contains(nomejogador));
            SendataByClient(socket._Socket, "msg" + "," + "Vc errou");
        }

        void SendataByClient(Socket socket, string msg)
        {
            System.Threading.Thread.Sleep(500);
            byte[] data = Encoding.ASCII.GetBytes(msg);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
        }
        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void SendataAll(string msg)
        {
                for (int j = 0; j < __ClientSockets.Count; j++)
                {
                    {
                        SendataByClient(__ClientSockets[j]._Socket, msg);
                        AddLog(__ClientSockets[j]._Socket + msg);
                    }
                }
        }

        private void lb_soluong_Click(object sender, EventArgs e)
        {

        }

        private void log_Click(object sender, EventArgs e)
        {

        }

        private void AddLog(string msg)
        {
            log.Text += msg + '\n';
        }
    }
}
