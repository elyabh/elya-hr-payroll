using ELYA.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddElyaSwagger();
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseElyaPipeline();
app.UseElyaSwagger();

app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }))
    .WithName("HealthCheck")
    .WithTags("Health")
    .AllowAnonymous();

app.MapControllers();
app.MapHealthChecks("/health/ready");

app.Run();
