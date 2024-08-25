using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizen.Core.CQRS.Handler;
using Aizen.Core.CQRS.Message;

namespace Aizen.Modules.CryptoStore.Application.Arbitrage;
public class ListenCoinMarketDataCommandHandler : AizenCommandHandler<ListenCoinMarketDataCommand, AizenCommandResult>
{
    public override bool IsTransactional => false;

    public override Task<AizenCommandResult?> Handle(ListenCoinMarketDataCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}