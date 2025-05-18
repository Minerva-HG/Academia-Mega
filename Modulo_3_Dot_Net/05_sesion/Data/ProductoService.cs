using Microsoft.Data.SqlClient; 
using PrimeraAPI.Models;
using Microsoft.Extensions.Configuration;

namespace PrimeraAPI.Data
{
    public class ProductoService
    {
        private readonly string _connectionString;

        public ProductoService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("TiendaDB");
        }

        //Obtener todos los productos
        public async Task<List<Producto>> GetAllAsync()
        {
            var productList = new List<Producto>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("SELECT * FROM Productos", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                productList.Add(new Producto
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                });
            }

            return productList;
        }

        //Obtener un producto por ID
        // public async Task<Producto> GetByIdAsync()
        // {

        // }

        //Crear un nuevo producto
        // public async Task<Producto> CreateAsync(Producto)
        // {

        // }

        //Actualizar producto

        //Eliminar producto
    }
}