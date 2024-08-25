using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.Starter;
using Aizen.Core.EventStore.Extension;
using Aizen.Modules.CryptoStore.Application.Arbitrage;

var builder = AizenApplicationBuilder.CreateBuilder(new AizenAppInfo
{
    Name = "Crypto",
    Type = AppType.Operation,
    TypeInclude = { AppType.Api, AppType.Worker, AppType.Scheduler }
}, args);

builder.Services.AddAizenEventStore(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var commandHandler = scope.ServiceProvider.GetRequiredService<ListenCoinMarketDataCommandHandler>();
    await commandHandler.Handle(new ListenCoinMarketDataCommand(), CancellationToken.None);
}

app.Run();
