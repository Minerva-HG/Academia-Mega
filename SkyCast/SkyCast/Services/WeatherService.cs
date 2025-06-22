// Importa soporte para trabajar con HTTP y deserializar JSON automáticamente
using System.Net.Http.Json;
// Importa soporte para acceder a configuración (como claves desde appsettings o secretos)
using Microsoft.Extensions.Configuration;

namespace SkyCast.Services;

/// <summary>
/// Servicio que se conecta a la API de OpenWeather para obtener datos del clima.
/// </summary>
public class WeatherService
{
    private readonly HttpClient _http; // Cliente HTTP para hacer peticiones a la API
    private readonly string _key;      // Clave de API para autenticarse con OpenWeather
    private const string baseURL = "https://api.openweathermap.org/data/2.5"; // URL base de la API

    /// <summary>
    /// Constructor que inyecta el HttpClient y lee la clave de API desde la configuración.
    /// </summary>
    /// <param name="http">Cliente HTTP proporcionado por el contenedor de dependencias.</param>
    /// <param name="config">Configuración del sistema (usualmente appsettings.json o secrets).</param>
    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _key = config["OPENWEATHER_KEY"] ?? ""; // Lee la clave desde la configuración
    }

    /// <summary>
    /// Obtiene el pronóstico del clima para una ciudad específica usando la API de OpenWeather.
    /// </summary>
    /// <param name="city">Nombre de la ciudad a consultar.</param>
    /// <returns>Objeto WeatherDto con la información del clima, o null si no se encuentra.</returns>
    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        // Construye la URL con el nombre de la ciudad, en unidades métricas y lenguaje español
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

        // Hace la petición HTTP y deserializa automáticamente la respuesta JSON a WeatherDto
        return await _http.GetFromJsonAsync<WeatherDto>(url);
    }
}
