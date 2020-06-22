using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaRodaJequitiClient.Models
{
    public class TipoMensagem
    {
        public string Type { get; set; }
        public Jogador jogador { get; set; }
        public ListaPalavras listaPalavras { get; set; }
        public ChuteLetra chuteLetra { get; set; }
        public ChutePalavra chutePalavra { get; set; }
        public Msg msg { get; set; }

        public Exit exit { get; set; }

        public class Exit
        {
            public string Nomejogador { get; set; }
            public bool Sair { get; set; }
        }

        public class Msg
        {
            public string msg { get; set; }
        }

        public class ChuteLetra
        {
            public string Nomejogador { get; set; }
            public string Letra { get; set; }
        }
        public class ChutePalavra
        {
            public string Nomejogador { get; set; }
            public string Palavra { get; set; }
            public int Indice { get; set; }
        }
        public class ListaPalavras
        {
            public List<string> Palavras { get; set; }
        }

        public class Jogador
        {
            public string Nomejogador { get; set; }
            public bool Ativo { get; set; }
            public int Pontos { get; set; }
        }
    }
}