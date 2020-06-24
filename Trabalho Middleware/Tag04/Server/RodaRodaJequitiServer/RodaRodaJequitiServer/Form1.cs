using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RodaRodaJequitiClient.Models;
using RodaRodaJequitiServer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RodaRodaJequitiClient.Models.TipoMensagem;

namespace RodaRodaJequitiServer
{
    public partial class Form1 : Form
    {
        public List<String> listaSecretaPalavras = new List<String>();
        public List<String> listaSecretaPalavrasCripto = new List<String>();
        public List<Jogador> listaJogadores = new List<Jogador>();
        private readonly Random _random = new Random();
        public int ValorPontosLetras = 0;
        public int ValorPontosPlavras = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaSecretaPalavras = PalavrasServices.SorteiaListaPalavras();
            listaSecretaPalavrasCripto = GerarListpalavrasCripto();
            AtualizaPontos();
        }

        // Verifica se a rodada acabou
        public void IsFimRodada()
        {
            var x1 = string.Join(",", listaSecretaPalavrasCripto.ToArray()).Contains("_");
            if (!x1)
            {
                InserirLog("Fim da Rodada");
                listaSecretaPalavras = PalavrasServices.SorteiaListaPalavras();
                listaSecretaPalavrasCripto = GerarListpalavrasCripto();
                InitRodada();
            }
        }

        // Inicia uma nova rodada
        private void InitRodada()
        {
            foreach (var x in list_Client.Items)
            {
                var msg = new TipoMensagem();
                var lists = new ListaPalavras();
                lists.Palavras = listaSecretaPalavrasCripto;
                msg.Type = "palavras";
                msg.listaPalavras = lists;
                var serializeObject = JsonConvert.SerializeObject(msg);
                EnviarMensagem(x.ToString(), "Nova Rodada comecando!");
                SendClient.PostQueue(x.ToString(), serializeObject);
            }
            InserirLog("Nova Rodada comecando!");
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private List<string> GerarListpalavrasCripto()
        {
            var list = new List<string>();
            foreach (var x in listaSecretaPalavras)
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

        public void Processa(string message)
        {
            var msg = JsonConvert.DeserializeObject<TipoMensagem>(message);
            switch (msg.Type)
            {
                case "jogador":
                    AddJogador(msg.jogador);
                    break;
                case "chuteletra":
                    ProcessarChute(msg.chuteLetra);
                    break;
                case "chutepalavra":
                    ProcessarPalavra(msg.chutePalavra);
                    break;
                case "exit":
                    RemoveJogador(msg.exit);
                    break;
            }
            AtualizaPlacar();
            IsFimRodada();
        }

        private void RemoveJogador(Exit exit)
        {
            try
            {
                var jogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(exit.Nomejogador));
                jogador.Ativo = false;
                list_Client.Items.Remove(jogador.Nomejogador);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void ProcessarPalavra(ChutePalavra chutePalavra)
        {
            if (GetJogadorAtual(chutePalavra.Nomejogador))
            {
                if (chutePalavra.Palavra.Equals(listaSecretaPalavras[chutePalavra.Indice]))
                {
                    listaSecretaPalavrasCripto[chutePalavra.Indice] = listaSecretaPalavras[chutePalavra.Indice];
                    var list = list_Client.Items;
                    foreach (var x in list)
                    {
                        var msg = new TipoMensagem();
                        var lists = new ListaPalavras();
                        lists.Palavras = listaSecretaPalavrasCripto;
                        msg.Type = "palavras";
                        msg.listaPalavras = lists;
                        var serializeObject = JsonConvert.SerializeObject(msg);
                        SendClient.PostQueue(x.ToString(), serializeObject);
                    }
                    AtualizaPontos();
                    listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(chutePalavra.Nomejogador)).Pontos += ValorPontosPlavras;
                    var msg2 = new TipoMensagem();
                    msg2.Type = "pontos";
                    msg2.jogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(chutePalavra.Nomejogador));
                    var serializeObject2 = JsonConvert.SerializeObject(msg2);
                    SendClient.PostQueue(chutePalavra.Nomejogador, serializeObject2);
                    EnviarNoticicaoSuaVez(chutePalavra.Nomejogador, "Acertou a palavra " + listaSecretaPalavrasCripto[chutePalavra.Indice]);
                }
                else
                {
                    ProximoJogador(chutePalavra.Nomejogador);
                }
            }
            else
            {
                sendNaoEsuaVez(chutePalavra.Nomejogador);
            }
        }

        private void ProcessarChute(ChuteLetra chuteLetra)
        {
            if (GetJogadorAtual(chuteLetra.Nomejogador))
            {
                var letra = chuteLetra.Letra;
                txtLetras.Text += letra + ", ";
                var p1 = listaSecretaPalavras[0].Split(letra.ToCharArray()).Length - 1;
                var p2 = listaSecretaPalavras[1].Split(letra.ToCharArray()).Length - 1;
                var p3 = listaSecretaPalavras[2].Split(letra.ToCharArray()).Length - 1;
                var quantidadeLetra = p1 + p2 + p3;
                var calcPontos = quantidadeLetra * Convert.ToInt32(ValorPontosLetras);
                AtualizaPontos();
                listaSecretaPalavrasCripto = VerifyListPalavrasChute(letra.ToCharArray()[0]);
                var list = list_Client.Items;
                foreach (var x in list)
                {
                    var msg = new TipoMensagem();
                    var lists = new ListaPalavras();
                    lists.Palavras = listaSecretaPalavrasCripto;
                    msg.Type = "palavras";
                    msg.listaPalavras = lists;
                    var serializeObject = JsonConvert.SerializeObject(msg);
                    SendClient.PostQueue(x.ToString(), serializeObject);
                }
                if (calcPontos == 0)
                {
                    ProximoJogador(chuteLetra.Nomejogador);
                }
                else
                {
                    listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(chuteLetra.Nomejogador)).Pontos += calcPontos;
                    var msg = new TipoMensagem();
                    msg.Type = "pontos";
                    msg.jogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(chuteLetra.Nomejogador));
                    var serializeObject = JsonConvert.SerializeObject(msg);
                    SendClient.PostQueue(chuteLetra.Nomejogador, serializeObject);
                    EnviarNoticicaoSuaVez(chuteLetra.Nomejogador, "Acertou " + quantidadeLetra + " letras " + letra);
                }
            }
            else
            {
                sendNaoEsuaVez(chuteLetra.Nomejogador);
            }
        }

        private void sendNaoEsuaVez(string nomejogador)
        {
            var msg = new TipoMensagem();
            msg.Type = "msg";
            var msn = new Msg();
            msn.msg = "Aguarde sua vez para jogar";
            msg.msg = msn;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendClient.PostQueue(nomejogador, serializeObject);
        }

        private bool GetJogadorAtual(string nomejogador)
        {
            var indice = list_Client.Items.IndexOf(nomejogador);
            return list_Client.GetItemChecked(indice);
        }


        private void ProximoJogador(string nomejogador)
        {
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
                EnviarNoticicaoSuaVez(nomeProximoJogador, "");
            }
        }

        private void EnviarNoticicaoSuaVez(string nomeProximoJogador, string mensagem)
        {
            var msg = new TipoMensagem();
            msg.Type = "msg";
            var msn = new Msg();
            msn.msg = mensagem + "\n Sua vez de jogar!";
            msg.msg = msn;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendClient.PostQueue(nomeProximoJogador, serializeObject);
        }

        private void EnviarNoticacaoErro(string nomejogador)
        {
            var msg = new TipoMensagem();
            msg.Type = "msg";
            var msn = new Msg();
            msn.msg = "Nao acerto, vez do proximo Jogador!";
            msg.msg = msn;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendClient.PostQueue(nomejogador, serializeObject);
        }

        private void EnviarMensagem(string nomejogador, string mensagem)
        {
            var msg = new TipoMensagem();
            msg.Type = "msg";
            var msn = new Msg();
            msn.msg = mensagem;
            msg.msg = msn;
            var serializeObject = JsonConvert.SerializeObject(msg);
            SendClient.PostQueue(nomejogador, serializeObject);
        }

        private void AddJogador(Jogador jogador)
        {
            var verificaJogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(jogador.Nomejogador));

            if (verificaJogador == null) // verifica se o jogador ja existi
            {
                if (list_Client.Items.Count == 0) // Primeiro jogador
                {
                    list_Client.Items.Add(jogador.Nomejogador);
                    var msg = new TipoMensagem();
                    var list = new ListaPalavras();
                    list.Palavras = GerarListpalavrasCripto();
                    msg.Type = "palavras";
                    msg.listaPalavras = list;
                    var serializeObject = JsonConvert.SerializeObject(msg);
                    SendClient.PostQueue(jogador.Nomejogador, serializeObject);
                    list_Client.SetItemChecked(0, true);
                    EnviarNoticicaoSuaVez(jogador.Nomejogador, "Primeiro jogador ");
                }
                else
                {
                    list_Client.Items.Add(jogador.Nomejogador);
                    var msg = new TipoMensagem();
                    var list = new ListaPalavras();
                    list.Palavras = GerarListpalavrasCripto();
                    msg.Type = "palavras";
                    msg.listaPalavras = list;
                    var serializeObject = JsonConvert.SerializeObject(msg);
                    SendClient.PostQueue(jogador.Nomejogador, serializeObject);
                    sendNaoEsuaVez(jogador.Nomejogador);
                }
                var jogadorNew = new Jogador();
                jogadorNew.Nomejogador = jogador.Nomejogador;
                jogadorNew.Ativo = true;
                jogadorNew.Pontos = 0;
                listaJogadores.Add(jogadorNew);
            }
            else
            {
                var indice = list_Client.Items.IndexOf(verificaJogador.Nomejogador);
                if (indice == -1)
                {
                    list_Client.Items.Add(verificaJogador.Nomejogador);
                }
                var msg = new TipoMensagem();
                var list = new ListaPalavras();
                list.Palavras = listaSecretaPalavrasCripto;
                msg.Type = "palavras";
                msg.listaPalavras = list;
                var serializeObject = JsonConvert.SerializeObject(msg);
                SendClient.PostQueue(jogador.Nomejogador, serializeObject);
                var msg2 = new TipoMensagem();
                msg2.Type = "pontos";
                msg2.jogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(verificaJogador.Nomejogador));
                var serializeObject2 = JsonConvert.SerializeObject(msg);
                SendClient.PostQueue(verificaJogador.Nomejogador, serializeObject2);
                sendNaoEsuaVez(jogador.Nomejogador);
            }
            InserirLog("Jogador " + jogador.Nomejogador + " adicionado");
        }

        public List<string> VerifyListPalavrasChute(char letra)
        {
            var list = new List<string>();
            for (var j = 0; j <= listaSecretaPalavrasCripto.Count - 1; j++)
            {
                var palavra = listaSecretaPalavras[j];
                var tamanho = palavra.Length;
                var auxRemoveChar = listaSecretaPalavrasCripto[j];
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

        // Cron
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SendServer",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var data = channel.BasicGet("SendServer", true);
                if (data != null)
                {
                    var message = System.Text.Encoding.UTF8.GetString(data.Body.ToArray());
                    Processa(message);
                }
            }
        }

        // Controla placar
        private void AtualizaPlacar()
        {
            listPlacar.Items.Clear();
            foreach (var jogador in listaJogadores.OrderByDescending(s => s.Pontos))
            {
                listPlacar.Items.Add("" + jogador.Nomejogador + "-" + jogador.Pontos);
            }
            InserirLog("Placar Atualizado");
        }

        private void AtualizaPontos()
        {
            ValorPontosLetras = RandomNumber(0, 1000);
            pontos.Text = ValorPontosLetras.ToString();

            ValorPontosPlavras = ValorPontosLetras * 10;
            pontosPalavra.Text = ValorPontosPlavras.ToString();
        }

        private void InserirLog(string log)
        {
            textLog.AppendText(DateTime.Now.ToString() + "-" + log + Environment.NewLine);
        }

        // Metodos Gerados pelo Form
        private void list_Client_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtLetras_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listPlacar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
