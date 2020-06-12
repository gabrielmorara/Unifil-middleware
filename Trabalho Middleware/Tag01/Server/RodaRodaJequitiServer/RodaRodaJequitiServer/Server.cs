using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RodaRodaJequitiServer
{
    public partial class Server : Form
    {
        public SimpleTcpServer server;
        public string IP = "127.0.0.1";
        public string Port = "8910";

        public List<String> secretlistPalavras = new List<String>();
        public List<String> listPalavrasChute = new List<String>();
        public int valorPontos = 100;
        public Server()
        {
            InitializeComponent();
            Server_Load();
        }

        private void Server_Load()
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

            MsgLog("Iniciando Servidor....");
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(IP);
            server.Start(ip, Convert.ToInt32(Port));
            MsgLog("Servidor Iniciado: " + IP + "," + Port);

            secretlistPalavras.Add("ABACAXI");
            secretlistPalavras.Add("UVA");
            secretlistPalavras.Add("TESTE");

            listPalavrasChute = GerarListpalavrasDefault();
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

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            MsgLog(e.MessageString);
            var receiverList = e.MessageString.Replace("\u0013", "");
            var type = receiverList.Split(',');
            switch (type[0])
            {
                case "Init":
                    Iniciar();
                    break;
                case "chute":
                    ProcessaChute(type);
                    break;
                default:
                    MsgLog("Erro:" + e.MessageString);
                    break;
            }
        }

        private void ProcessaChute(string[] type)
        {
            var player = type[1];
            var letra = type[2];
            var pontos = type[3];

            var p1 = secretlistPalavras[0].Split(letra.ToCharArray()).Length - 1;
            var p2 = secretlistPalavras[1].Split(letra.ToCharArray()).Length - 1;
            var p3 = secretlistPalavras[2].Split(letra.ToCharArray()).Length - 1;

            var calcPontos = (p1 + p2 + p3) * Convert.ToInt32(valorPontos);
            listPalavrasChute = VerifyListPalavrasChute(letra.ToCharArray()[0]);
            sendToClient("chute" + "," + converterListToString(listPalavrasChute));
            if (calcPontos > 0)
            {
                System.Threading.Thread.Sleep(1000);
                sendToClient("puntuacao" + "," + player + "," + calcPontos + ",");
                valorPontos += valorPontos;
                sendToClient("pontos" + "," + valorPontos + ",");
                System.Threading.Thread.Sleep(1000);
                sendToClient("msg" + "," + " Jogador " + player + " acertou " + (p1 + p2 + p3) + " letra " + letra + ",");
            }
            else
            {
                sendToClient("msg" + "," + " Jogador " + player + " nao acertou nenhuma letra " + letra);
            }
        }

        public void Iniciar()
        {
            sendToClient("Init" + "," + converterListToString(GerarListpalavrasDefault()));
            System.Threading.Thread.Sleep(1000);
            sendToClient("pontos" + "," + valorPontos);
        }

        public string converterListToString(List<string> listPalavras)
        {
            return listPalavras[0] + "," + listPalavras[1] + "," + listPalavras[2];
        }

        public void sendToClient(string msg)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(msg);
            server.Broadcast(bytesToSend);
        }

        public void MsgLog(string mensagem)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(MsgLog), new object[] { mensagem });
                return;
            }

            Log.AppendText(DateTime.Now + " - " + mensagem + Environment.NewLine);
        }
    }
}
