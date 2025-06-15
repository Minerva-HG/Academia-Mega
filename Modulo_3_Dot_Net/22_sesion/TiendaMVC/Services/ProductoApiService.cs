using System.Net.Http.Json;
using System.Net.Http.Headers;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ProductoApiService : IProductoApiService
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _context;
        public ProductoApiService(HttpClient http, IHttpContextAccessor context)
        {
            _http = http;
            _context = context;

            var token = _context.HttpContext!.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        } 

        //Listado de productos
        public async Task<List<Producto>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<Producto>>("api/productos") ?? new List<Producto>();

        //Producto por ID
        public async Task<Producto?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");

        //Crear producto
        public async Task<Producto?> CreateAsync(Producto p)
        {
            var response = await _http.PostAsJsonAsync("api/productos", p);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        //Actualizar producto
        public async Task<bool> UpdateAsync(int id, Producto p)
        {
            var response = await _http.PutAsJsonAsync(($"api/productos/{id}"), p);

            return response.IsSuccessStatusCode;
        }

        //Eliminar producto
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/productos/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}