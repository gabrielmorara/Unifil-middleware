using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftS.Common.Attributes;
using static ThriftS.Test.Contract.TipoMensagem;

namespace ThriftS.Test.Contract
{
    [ThriftSContract(ServiceName = "contract.IRodaRodaService")]
    public interface IRodaRodaService
    {
        [ThriftSOperation]
        TipoMensagem PalavrasCripto(TipoMensagem tipoMensagem);

        [ThriftSOperation]
        TipoMensagem ChutePalavra(TipoMensagem tipoMensagem);

        [ThriftSOperation]
        TipoMensagem ChuteLetra(TipoMensagem tipoMensagem);

        [ThriftSOperation]
        TipoMensagem AddJogador(Jogador jogador);
    }
}
