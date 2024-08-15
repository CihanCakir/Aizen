using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.Starter;
using Aizen.Core.EventStore.Extension;

var builder = AizenApplicationBuilder.CreateBuilder(new AizenAppInfo
{
    Name = "Fraud",
    Type = AppType.Operation,
    TypeInclude = { AppType.Api, AppType.Worker, AppType.Scheduler }
}, args);

builder.Services.AddAizenEventStore(builder.Configuration);

var app = builder.Build();
app.Run();
