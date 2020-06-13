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
                case "palavra":
                    ExibirPalavra(list);
                    break;
                case "msg":
                    ExibirMsg(list);
                    break;
                default:
                    break;
            }
        }

        private void ExibirPalavra(string[] list)
        {
            var player = list[1];
            var resultado = list[2];
            if (resultado.Equals("acertou"))
            {
                var indicePalavra = list[3];
                var palavraCorreta = list[4];
                var pontos = list[5];

                switch (indicePalavra)
                {
                    case "0":
                        label5.Text = palavraCorreta;
                        break;
                    case "1":
                        label3.Text = palavraCorreta;
                        break;
                    case "2":
                        label4.Text = palavraCorreta;
                        break;
                }
                var prodsad = "0" + "," + player + "," + pontos;
                ExibirPuntuacao(prodsad.Split(','));
                msg.Text = "Jogador " + player + " acertou a palavra " + palavraCorreta;
            }
            else
            {
                msg.Text = "Jogador " + player + " errou a palavra";
                proximoJogador();
            }
        }

        private void ExibirMsg(string[] list)
        {
            msg.Text = list[1].ToString();
            if (list[1].ToString().Contains("nenhuma"))
            {
                proximoJogador();
            }
        }

        public void proximoJogador()
        {
            var jogador = Convert.ToInt32(player.Text) + 1;
            if (jogador <= 3)
            {
                player.Text = jogador.ToString();

            }
            else
            {
                player.Text = "1";
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
                    pontos2.Text = total.ToString();
                    break;
                case "3":
                    total = Convert.ToInt32(pontos3.Text) + Convert.ToInt32(pontos);
                    pontos3.Text = total.ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            EnviarPalavra("0", player.Text, textBox1.Text);
        }

        private void EnviarPalavra(string palavra, string player, string palavraChute)
        {
            var list = "palavra" + "," + player + "," + palavra + "," + palavraChute;
            SendToServer(list);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnviarPalavra("1", player.Text, textBox2.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EnviarPalavra("2", player.Text, textBox3.Text);
        }
    }
}
