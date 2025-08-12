using Serilog;
using Servicio.Sensor;
using Servicio.Metrics;
using Servicio;
using Microsoft.Extensions.Options;


var builder = Host.CreateApplicationBuilder(args);


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File(
        path: "logs/termicologs-.csv",
        outputTemplate: "{Timestamp:0};{Message:lj}{NewLine}",
        rollingInterval: RollingInterval.Day
    ).CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();


// Inyectar las dependencias
builder.Services.AddSingleton<HardwareReader>();
builder.Services.AddSingleton<CsWriter>();
builder.Services.AddHostedService<MetricExporter>();
builder.Services.AddHostedService<Worker>();


if (OperatingSystem.IsWindows() && !args.Contains("--console"))
{
    builder.Services.AddWindowsService(Options =>
        Options.ServiceName = "Termico");
}

await builder.Build().RunAsync();