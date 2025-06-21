// Autor: Minerva Herandez Godinez
// Servicio para obtener información del clima desde OpenWeatherMap.

using System.Net.Http.Json; // Importa métodos de extensión para trabajar con JSON en HTTP.
using Microsoft.Extensions.Configuration; // Permite acceder a la configuración de la aplicación.

namespace SkyCast.Services; // Define el espacio de nombres para los servicios de SkyCast.

public class WeatherService // Clase principal del servicio del clima.
{
    private readonly HttpClient _http; // Cliente HTTP para realizar solicitudes web.
    private readonly string _key; // Almacena la clave API de OpenWeather.
    private const string baseURL = "https://openweathermap.org/data/2.5/"; // URL base de la API de OpenWeather.

    // Constructor que recibe el cliente HTTP y la configuración.
    public WeatherService(HttpClient http, IConfiguration config)
    {
        _http = http; // Asigna el cliente HTTP recibido.
        _key = config["OpenWeather.key"] ?? ""; // Obtiene la clave API desde la configuración.
    }

    // Método asíncrono para obtener el clima por ciudad.
    public async Task<WeatherDto?> GetByCityAsync(string city)
    {
        // Construye la URL con la ciudad, unidades métricas, clave API y lenguaje español.
        var url = $"{baseURL}/weather?q={Uri.EscapeDataString(city)}&units=metric&appid={_key}&lang=es";

        // Realiza la solicitud HTTP y deserializa la respuesta a WeatherDto.
        return await _http.GetFromJsonAsync<WeatherDto>(url);
    }
}