using ELYA.Application;
using ELYA.Infrastructure;
using ELYA.Persistence;
using ELYA.Worker.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddHangfirePlaceholder(builder.Configuration);

var host = builder.Build();
host.Run();
