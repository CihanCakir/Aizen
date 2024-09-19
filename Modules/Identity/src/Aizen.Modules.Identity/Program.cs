using Aizen.Core.Domain.Abstraction.Extention;
using Aizen.Core.InfoAccessor.Abstraction;
using Aizen.Core.Infrastructure.UnitOfWork.Extention;
using Aizen.Core.Starter;
using Aizen.Modules.Identity.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = AizenApplicationBuilder.CreateBuilder(new AizenAppInfo
{
    Name = "Identity",
    Type = AppType.Operation,
    TypeInclude = {AppType.Api,AppType.Worker,AppType.Scheduler}
}, args);

builder.Services.AddAizenUnitOfWork<AizenIdentityDbContext>(builder.Configuration, "Identity", options =>
{
    options.UseMigration = true;
    options.MigrationAssembly = "Aizen.Modules.Identity.Repository";
});

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection(nameof(ApplicationSettings)));
var app = builder.Build();
app.Run();