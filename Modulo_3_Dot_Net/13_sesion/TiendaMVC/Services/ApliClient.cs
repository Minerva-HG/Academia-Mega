using System.Net.Http.Headers;
using TiendaMVC.Models;

namespace TiendaMVC.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly IHttpContextAccessor _context;

        public ApiClient(HttpClient http, IHttpContextAccessor context)
        {
            _http = http;
            _context = context;

            //Si es que hay un token de sesión, lo incluimos en cada petición            
            var token = _context.HttpContext!.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        }

        //public Task<List<Producto>> GetProductosAsync() =>
        public Task<List<Producto>> GetProductosAsync()
            => _http.GetFromJsonAsync<List<Producto>>("api/productos"!);

        public async Task<Producto?> GetProductoByIdAsync(int id) =>
            await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");

        public async Task<Producto?> CreateProductoAsync(Producto p)
        {
            var response = await _http.PostAsJsonAsync("api/productos", p);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<bool> UpdateProductoAsync(int id, Producto p)
        {
            var response = await _http.PutAsJsonAsync($"api/productos/{id}", p);
            return response.IsSuccessStatusCode;
        }

     public async Task<bool> DeleteProductoAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/productos/{id}");
            return response.IsSuccessStatusCode;
        }


        /*
        La siguiente es la implementación de las llamadas que tienen que ver con el usuario ....
        */


        public async Task<bool> LoginAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/login", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;

        }

        public async Task<bool> RegisterAsync(User user)
        {
            var response = await _http.PostAsJsonAsync("/api/auth/registro", user);
            if (!response.IsSuccessStatusCode) return false;
            var obj = await response.Content.ReadFromJsonAsync<TokenResponse>();
            _context.HttpContext!.Session.SetString("JWToken", obj!.Token);
            return true;
        }

    }

    //Autenticación

    public class TokenResponse { public string Token { get; set; } = ""; }

}