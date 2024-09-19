using Aizen.Core.Domain.Abstraction.Extention;
using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.Starter;

var builder = AizenApplicationBuilder.CreateBuilder(new AizenAppInfo
{
    Name = "DataStore",
    Type = AppType.Operation,
    TypeInclude = { AppType.Api, AppType.Worker, AppType.Scheduler }
}, args);
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection(nameof(ApplicationSettings)));

var app = builder.Build();
app.Run();