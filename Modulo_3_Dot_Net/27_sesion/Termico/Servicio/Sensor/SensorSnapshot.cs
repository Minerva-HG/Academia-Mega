namespace Servicio.Sensor;

public record SensorSnapshot(
    DateTime Timestamp,
    float? CpuTemp,
    float? GpuTemp,
    float? CpuLoad,
    float? GpuLoad,
    int MemoryUseMb,
    int FanRpm
);