// Autor: Minerva Herandez Godinez
namespace SkyCast.Services;

/// <summary>
/// Representa la respuesta principal del servicio de clima.
/// Contiene el nombre de la ciudad, los datos meteorológicos principales y la lista de condiciones del clima.
/// </summary>
/// <param name="Name">Nombre de la ciudad.</param>
/// <param name="Main">Datos principales del clima como temperatura y humedad.</param>
/// <param name="Weather">Lista de condiciones climáticas (generalmente una sola entrada).</param>
public record WeatherDto(string Name, MainData Main, IEnumerable<WeatherInfo> Weather);

/// <summary>
/// Representa los datos principales del clima.
/// </summary>
/// <param name="Temp">Temperatura en grados Celsius.</param>
/// <param name="Humidity">Porcentaje de humedad.</param>
public record MainData(double Temp, double Humidity);

/// <summary>
/// Representa una condición específica del clima, como nublado, soleado, etc.
/// </summary>
/// <param name="Description">Descripción textual del clima (en español si se especificó en la petición).</param>
/// <param name="Icon">Código del ícono correspondiente al estado del clima.</param>
public record WeatherInfo(string Description, string Icon);
