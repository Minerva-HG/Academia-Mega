using LibreHardwareMonitor.Hardware;

namespace Servicio.Sensor;

/// <summary> Wrapper de LibreHardwareMonitor para leer los sensores </summary>
public sealed class HardwareReader : IVisitor
{
    private readonly Computer _computer;

    // Las últimas lecturas
    private float? _cpuTemp, _gpuTemp, _cpuLoad, _gpuLoad;
    private int _memUsed, _fan;

    public HardwareReader()
    {
        _computer = new Computer
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsControllerEnabled = true,
        };
        _computer.Open();
    }

    public SensorSnapshot Capture()
    {
        _computer.Accept(this);
        return new SensorSnapshot(
            Timestamp: DateTime.Now,
            CpuTemp: _cpuTemp,
            CpuLoad: _cpuLoad,
            GpuTemp: _gpuTemp,
            GpuLoad: _gpuLoad,
            MemoryUseMb: _memUsed,
            FanRpm: _fan
        );
    }

    public void VisitComputer(IComputer computer)
    {
        foreach (var hw in computer.Hardware)
        {
            hw.Update();
            hw.Accept(this);
        }   
    }

    public void VisitHardware(IHardware hardware)
    {
        foreach (var sensor in hardware.Sensors)
            VisitSensor(sensor);
    }

    public void VisitSensor(ISensor sensor)
    {
        switch (sensor.SensorType)
        {
            case SensorType.Temperature:
                if (sensor.Name.Contains("CPU", StringComparison.OrdinalIgnoreCase))
                    _cpuTemp = sensor.Value;
                if (sensor.Name.Contains("GPI", StringComparison.OrdinalIgnoreCase))
                    _gpuTemp = sensor.Value;
                break;

            case SensorType.Load:
                if (sensor.Name.Contains("CPU Total"))
                    _cpuLoad = sensor.Value;
                if (sensor.Name.Contains("GPU Total"))
                    _gpuLoad = sensor.Value;
                break;

            case SensorType.Fan:
                _fan = (int?)sensor.Value ?? _fan;
                break;

            case SensorType.Data:
                if (sensor.Name.Equals("Memory Used", StringComparison.OrdinalIgnoreCase))
                    _memUsed = (int)((sensor.Value ?? 0) / 1024);
                break;
        }
    }

    public void VisitParameter(IParameter parameter)
    {
        throw new NotImplementedException();
    }
}