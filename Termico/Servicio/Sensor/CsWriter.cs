using System.Globalization;
using System.Text;

namespace Servicio.Sensor;

public sealed class CsWriter
{
    private const string Header =
        "Timestamp;CpuTemp;GpuTemp;CpuLoad;GpuLoad;MemoryMB;FanRpm";

    private readonly string _path = "logs";
    private readonly object _sync = new();

    public CsWriter()
    {
        Directory.CreateDirectory(_path); 
    }

    public void Write(SensorSnapshot s)
    {
        var file = Path.Combine(_path, $"{DateTime.Today:yyyyMMdd}.csv");

        var sb = new StringBuilder()
            .Append(s.Timestamp.ToString("0")).Append(';')
            .Append(s.CpuTemp).Append(';')
            .Append(s.GpuTemp).Append(';')
            .Append(s.CpuLoad).Append(';')
            .Append(s.GpuLoad).Append(';')
            .Append(s.MemoryUseMb).Append(';')
            .Append(s.FanRpm);

        lock (_sync)
        {
            var writeHeader = !File.Exists(file);
            using var sw = new StreamWriter(file, append: true, Encoding.UTF8);
            if (writeHeader)
                sw.WriteLine(Header);
            sw.WriteLine(sb.ToString());
        }
    }
    
}