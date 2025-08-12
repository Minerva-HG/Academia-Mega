using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;
using Servicio.Sensor;

namespace Servicio.Metrics;

/// <summary> Expone las métricas a OpenTelemetry </summary>
public sealed class MetricExporter : BackgroundService
{

    public static readonly Meter meter = new("Termico", "1.0");
    private readonly HardwareReader _reader;
    private readonly ILogger<MetricExporter> _log;
    private readonly Histogram<float> _cpuTemp = meter.CreateHistogram<float>("cpu_temp_c");
    private readonly Histogram<float> _gpuTemp = meter.CreateHistogram<float>("gpu_temp_c");

    public MetricExporter(HardwareReader reader, ILogger<MetricExporter> log)
        => (_reader, _log) = (reader, log);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var s = _reader.Capture();
            if (s.CpuTemp is { } c) _cpuTemp.Record(c);
            if (s.GpuTemp is { } g) _gpuTemp.Record(g);
            await Task.Delay(5000, stoppingToken);
        }
    }
}