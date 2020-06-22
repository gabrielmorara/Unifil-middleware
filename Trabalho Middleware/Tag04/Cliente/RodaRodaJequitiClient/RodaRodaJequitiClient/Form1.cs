using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RodaRodaJequitiClient.Models;
using RodaRodaJequitiClient.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RodaRodaJequitiClient.Models.TipoMensagem;

namespace RodaRodaJequitiClient
{
    public partial class Form1 : Form
    {
        public static string nome = "";
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            var msg = new TipoMensagem();
            msg.Type = "exit";
            var exit = new Exit();
            exit.Sair = true;
            exit.Nomejogador = nome;
            msg.exit = exit;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendServer.PostQueue(serializeObject);
        }

        private void ProcessaFila(string message)
        {
            var msg = JsonConvert.DeserializeObject<TipoMensagem>(message);
            switch (msg.Type)
            {
                case "palavras":
                    InicializaPalavras(msg.listaPalavras);
                    break;
                case "msg":
                    ExibirMsg(msg.msg);
                    break;
                case "pontos":
                    ExibirPontos(msg.jogador);
                    break;
            }
        }

        private void ExibirPontos(Jogador jogador)
        {
            pontos.Text = jogador.Pontos.ToString();
        }

        private void ExibirMsg(Msg msg)
        {
            label9.Text = msg.msg;
        }

        private void InicializaPalavras(ListaPalavras listaPalavras)
        {
            try
            {
                palavra01.Text = listaPalavras.Palavras[0];
                palavra02.Text = listaPalavras.Palavras[1];
                palavra03.Text = listaPalavras.Palavras[2];

            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void txName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnJogar_Click(object sender, EventArgs e)
        {
            nome = txtNamePlayer.Text.ToUpper();
            var jogador = new Jogador();
            jogador.Nomejogador = nome;
            var msg = new TipoMensagem();
            msg.Type = "jogador";
            msg.jogador = jogador;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendServer.PostQueue(serializeObject);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            if (nome != null && nome != "")
            {
                var NameFila = nome;
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: NameFila,

                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var data = channel.BasicGet(NameFila, true);
                    if (data != null)
                    {
                        var message = System.Text.Encoding.UTF8.GetString(data.Body.ToArray());
                        ProcessaFila(message);
                    }
                }
            }
            return;
        }

        private void palavra01_Click(object sender, EventArgs e)
        {

        }

        private void palavra02_Click(object sender, EventArgs e)
        {

        }

        private void palavra03_Click(object sender, EventArgs e)
        {

        }

        private void btnLetra_Click(object sender, EventArgs e)
        {
            var msg = new TipoMensagem();
            msg.Type = "chuteletra";
            var letra = new ChuteLetra();
            letra.Nomejogador = nome;
            letra.Letra = txtLetra.Text;
            msg.chuteLetra = letra;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendServer.PostQueue(serializeObject);
        }


        private void EnviarPalavra(ChutePalavra palavra, int indice)
        {
            var msg = new TipoMensagem();
            msg.Type = "chutepalavra";
            palavra.Nomejogador = nome;
            palavra.Indice = indice;
            palavra.Palavra = palavra.Palavra.ToUpper();
            msg.chutePalavra = palavra;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendServer.PostQueue(serializeObject);
        }
        private void btnPalavra01_Click(object sender, EventArgs e)
        {
            var palavra = new ChutePalavra();
            palavra.Palavra = textBox1.Text;
            EnviarPalavra(palavra, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPalavra02_Click(object sender, EventArgs e)
        {
            var palavra = new ChutePalavra();
            palavra.Palavra = textBox2.Text;
            EnviarPalavra(palavra, 1);
        }

        private void btnPalavra03_Click(object sender, EventArgs e)
        {
            var palavra = new ChutePalavra();
            palavra.Palavra = textBox3.Text;
            EnviarPalavra(palavra, 2);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
