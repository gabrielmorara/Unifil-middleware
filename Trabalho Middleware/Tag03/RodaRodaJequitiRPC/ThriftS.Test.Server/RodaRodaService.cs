using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThriftS.Service;
using ThriftS.Test.Contract;
using static ThriftS.Test.Contract.TipoMensagem;

namespace ThriftS.Test.Server
{
    public class RodaRodaService : IRodaRodaService
    {
        public static List<String> listaSecretaPalavras = new List<String>();
        public static List<String> listaSecretaPalavrasCripto = new List<String>();
        public static List<Jogador> listaJogadores = new List<Jogador>();
        private static readonly Random _random = new Random();
        public static int ValorPontos = 0;

        public RodaRodaService()
        {
            if (listaSecretaPalavras.Count == 0)
            {
                listaSecretaPalavras = Palavras.SorteiaListaPalavras();
            }
            if (listaSecretaPalavrasCripto.Count == 0)
            {
                listaSecretaPalavrasCripto = GerarListpalavrasCripto();
            }
            RandomNumber();
        }

        public TipoMensagem AddJogador(Jogador jogador)
        {
            _ = new RodaRodaService();
            var response = new TipoMensagem();
            var verificaJogador = listaJogadores.FirstOrDefault(s => s.Nomejogador.Equals(jogador.Nomejogador));
            if (verificaJogador == null)
            {
                if (listaJogadores.Count == 0)
                {
                    jogador.Ativo = true;
                    listaJogadores.Add(jogador);
                    var palavras = new ListaPalavras();
                    palavras.Palavras = listaSecretaPalavrasCripto;
                    response.listaPalavras = palavras;
                }
                else
                {
                    listaJogadores.Add(jogador);
                    var palavras = new ListaPalavras();
                    palavras.Palavras = listaSecretaPalavrasCripto;
                    response.listaPalavras = palavras;
                }
            }
            return response;
        }

        public TipoMensagem ChuteLetra(TipoMensagem tipoMensagem)
        {
            if (GetJogadorAtual(tipoMensagem.chuteLetra.Nomejogador))
            {
                var letra = tipoMensagem.chuteLetra.Letra;
                var p1 = listaSecretaPalavras[0].Split(letra.ToCharArray()).Length - 1;
                var p2 = listaSecretaPalavras[1].Split(letra.ToCharArray()).Length - 1;
                var p3 = listaSecretaPalavras[2].Split(letra.ToCharArray()).Length - 1;
                var quantidadeLetra = p1 + p2 + p3;
                var calcPontos = quantidadeLetra * Convert.ToInt32(ValorPontos);
                RandomNumber();
                listaSecretaPalavrasCripto = VerifyListPalavrasChute(letra.ToCharArray()[0]);

                var lists = new ListaPalavras();
                lists.Palavras = listaSecretaPalavrasCripto;

                tipoMensagem.listaPalavras = lists;

                tipoMensagem.jogador.Pontos += calcPontos;

                tipoMensagem.msg.msg = "Acertou " + quantidadeLetra + " letras " + letra;

                if (calcPontos == 0)
                {
                    proximoJogador(tipoMensagem.chuteLetra.Nomejogador);
                }
            }
            return tipoMensagem;
        }

        public TipoMensagem ChutePalavra(TipoMensagem tipoMensagem)
        {
            if (GetJogadorAtual(tipoMensagem.jogador.Nomejogador))
            {
                if (tipoMensagem.chutePalavra.Palavra.Equals(listaSecretaPalavras[tipoMensagem.chutePalavra.Indice]))
                {
                    listaSecretaPalavrasCripto[tipoMensagem.chutePalavra.Indice] = listaSecretaPalavras[tipoMensagem.chutePalavra.Indice];

                    var calcPontos = 10 * Convert.ToInt32(ValorPontos);

                    var lists = new ListaPalavras();
                    lists.Palavras = listaSecretaPalavrasCripto;

                    tipoMensagem.listaPalavras = lists;

                    tipoMensagem.jogador.Pontos += calcPontos;

                    tipoMensagem.msg.msg = "Acertou a palavra " + listaSecretaPalavrasCripto[tipoMensagem.chutePalavra.Indice];
                }
                else
                {
                    proximoJogador(tipoMensagem.chutePalavra.Nomejogador);
                }
            }
            return tipoMensagem;
        }

        public TipoMensagem PalavrasCripto(TipoMensagem tipoMensagem)
        {
            throw new NotImplementedException();
        }

        // Metodos Aux

        private void proximoJogador(string nomejogador)
        {
            var jogadorAtual = listaJogadores.FindIndex(s => s.Nomejogador.Equals(nomejogador));
            var novoJogadorAtual = jogadorAtual + 1;
            try
            {
                listaJogadores[novoJogadorAtual].Ativo = true;
                listaJogadores[jogadorAtual].Ativo = false;
            }
            catch (Exception e)
            {
                novoJogadorAtual = 0;
                listaJogadores[novoJogadorAtual].Ativo = true;
                listaJogadores[jogadorAtual].Ativo = false;
            }
        }

        private bool GetJogadorAtual(string nomejogador)
        {
            var indice = listaJogadores.Where(s => s.Nomejogador.Equals(nomejogador)).FirstOrDefault();
            return indice.Ativo;
        }

        public void RandomNumber()
        {
            ValorPontos = _random.Next(0, 1000);
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
    }
}