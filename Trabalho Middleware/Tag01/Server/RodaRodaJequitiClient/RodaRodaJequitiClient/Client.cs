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

namespace RodaRodaJequitiClient
{
    public partial class Client : Form
    {
        public SimpleTcpClient client;
        public string IP = "127.0.0.1";
        public string Port = "8910";
        public int JogadorInicial = 0;

        public Client()
        {
            InitializeComponent();
            Client_Load();
        }

        public void Client_Load()
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
            client.Connect(IP, Convert.ToInt32(Port));
            SendToServer("Init" + ",");
            CheckForIllegalCrossThreadCalls = false;
        }

        // Recebe dados do servidor
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            var list = e.MessageString.Split(',');
            var type = list[0];
            switch (type)
            {
                case "Init":
                case "chute":
                    IniciarJogo(list);
                    break;
                case "pontos":
                    ExibirPontos(list);
                    break;
                case "puntuacao":
                    ExibirPuntuacao(list);
                    break;
                case "msg":
                    ExibirMsg(list);
                    break;
                default:
                    break;
            }
        }

        private void ExibirMsg(string[] list)
        {
            msg.Text = list[1].ToString();
            if (list[1].ToString().Contains("nenhuma"))
            {
                var jogador = Convert.ToInt32(player.Text) + 1;
                player.Text = jogador.ToString();
            }
        }

        private void ExibirPuntuacao(string[] list)
        {
            var player = list[1];
            var pontos = list[2];
            var total = 0;
            switch (player)
            {
                case "1":
                    total = Convert.ToInt32(pontos1.Text) + Convert.ToInt32(pontos);
                    pontos1.Text = total.ToString();
                    break;
                case "2":
                    total = Convert.ToInt32(pontos2.Text) + Convert.ToInt32(pontos);
                    pontos1.Text = total.ToString();
                    break;
                case "3":
                    total = Convert.ToInt32(pontos3.Text) + Convert.ToInt32(pontos);
                    pontos1.Text = total.ToString();
                    break;
            }
        }

        // Envia dados para o servidor
        public void SendToServer(string msg)
        {
            client.WriteLine(msg);
        }

        public void IniciarJogo(string[] list)
        {
            label5.Text = list[1].ToString();
            label3.Text = list[2].ToString();
            label4.Text = list[3].ToString();
        }

        public void ExibirPontos(string[] list)
        {
            valendo.Text = list[1].ToString();
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = "chute" + "," + player.Text + "," + letra.Text + "," + valendo.Text;
            client.WriteLine(list);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void msg_Click(object sender, EventArgs e)
        {

        }
    }
}
