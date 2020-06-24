using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftS.Common.Attributes;

namespace ThriftS.Test.Contract
{
    [ThriftSModel]
    public class TipoMensagem
    {
        [ThriftSMember(1)]
        public string Type { get; set; }
        [ThriftSMember(2)]
        public Jogador jogador { get; set; }
        [ThriftSMember(3)]
        public ListaPalavras listaPalavras { get; set; }
        [ThriftSMember(4)]
        public ChuteLetra chuteLetra { get; set; }
        [ThriftSMember(5)]
        public ChutePalavra chutePalavra { get; set; }
        [ThriftSMember(6)]
        public Exit exit { get; set; }
        [ThriftSMember(7)]
        public Msg msg { get; set; }

        [ThriftSModel]
        public class Exit
        {
            [ThriftSMember(1)]
            public string Nomejogador { get; set; }
            [ThriftSMember(2)]
            public bool Sair { get; set; }
        }

        [ThriftSModel]
        public class Msg
        {
            [ThriftSMember(1)]
            public string msg { get; set; }
        }
        [ThriftSModel]
        public class ChuteLetra
        {
            [ThriftSMember(1)]
            public string Nomejogador { get; set; }
            [ThriftSMember(2)]
            public string Letra { get; set; }
        }
        [ThriftSModel]
        public class ChutePalavra
        {
            [ThriftSMember(1)]
            public string Nomejogador { get; set; }
            [ThriftSMember(2)]
            public string Palavra { get; set; }
            [ThriftSMember(3)]
            public int Indice { get; set; }
        }
        [ThriftSModel]
        public class ListaPalavras
        {
            [ThriftSMember(1)]
            public List<string> Palavras { get; set; }
        }

        [ThriftSModel]
        public class Jogador
        {
            [ThriftSMember(1)]
            public string Nomejogador { get; set; }
            [ThriftSMember(2)]
            public bool Ativo { get; set; }
            [ThriftSMember(3)]
            public int Pontos { get; set; }
        }
    }
}
