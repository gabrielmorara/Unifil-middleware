using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThriftS.Client;
using ThriftS.Common;
using ThriftS.Test.Contract;
using static ThriftS.Test.Contract.TipoMensagem;

namespace ThriftS.Test.Client
{
    public partial class Form1 : Form
    {
        private IRodaRodaService proxy;

        public Form1()
        {
            InitializeComponent();
            ThriftSClient client = new ThriftSClient("127.0.0.1", 8384);
            proxy = client.CreateProxy<IRodaRodaService>();
        }

        // Evento apos realizar o clique no botao jogar 
        private void btnJogar_Click(object sender, EventArgs e)
        {
            var jogador = new Jogador();
            jogador.Nomejogador = txtNamePlayer.Text.ToUpper();
            var x = proxy.AddJogador(jogador);
            InicializaPalavras(x.listaPalavras);
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

        private void btnLetra_Click(object sender, EventArgs e)
        {
            var msg = new TipoMensagem();
            msg.Type = "chuteletra";
            var jogador = new Jogador();
            jogador.Nomejogador = txtNamePlayer.Text.ToUpper();
            jogador.Pontos = Convert.ToInt32(pontos.Text);
            var textoMsg = new Msg();
            textoMsg.msg = "";
            var letra = new ChuteLetra();
            letra.Nomejogador = txtNamePlayer.Text.ToUpper();
            letra.Letra = txtLetra.Text.ToUpper();
            msg.chuteLetra = letra;
            msg.jogador = jogador;
            msg.msg = textoMsg;
            var response = proxy.ChuteLetra(msg);
            ProcessaResponse(response);
        }

        private void EnviarPalavra(ChutePalavra palavra, int indice)
        {
            var msg = new TipoMensagem();
            msg.Type = "chutepalavra";
            var jogador = new Jogador();
            jogador.Nomejogador = txtNamePlayer.Text.ToUpper();
            jogador.Pontos = Convert.ToInt32(pontos.Text);
            var textoMsg = new Msg();
            textoMsg.msg = "";
            palavra.Nomejogador = txtNamePlayer.Text.ToUpper();
            palavra.Indice = indice;
            palavra.Palavra = palavra.Palavra.ToUpper();
            msg.chutePalavra = palavra;
            var response = proxy.ChutePalavra(msg);
            msg.msg = textoMsg;
            InicializaPalavras(response.listaPalavras);
            ProcessaResponse(response);
        }

        public void ProcessaResponse(TipoMensagem response)
        {
            if (response.listaPalavras != null)
            {
                InicializaPalavras(response.listaPalavras);
            }
            if (response.jogador != null)
            {
                ExibirPontos(response.jogador);
            }
            if (response.msg != null)
            {
                ExibirMsg(response.msg);
            }
        }

        private void btnPalavra01_Click(object sender, EventArgs e)
        {
            var palavra = new ChutePalavra();
            palavra.Palavra = textBox1.Text;
            EnviarPalavra(palavra, 0);
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

        private void ExibirPontos(Jogador jogador)
        {
            pontos.Text = jogador.Pontos.ToString();
        }

        private void ExibirMsg(Msg msg)
        {
            label9.Text = msg.msg;
        }
    }
}