using LibreHardwareMonitor.Hardware;
using Servicio.Sensor;

namespace Servicio;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly HardwareReader _reader;
    private readonly CsWriter _csv;
    private readonly int _intervalo;

    public Worker(
        ILogger<Worker> logger,
        HardwareReader reader,
        CsWriter csv,
        IConfiguration config
        )
    {
        _logger = logger;
        _reader = reader;
        _csv = csv;
        _intervalo = config.GetValue("Sampler:IntervaMs", 5000);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
