using Microsoft.Data.SqlClient; 
using PrimeraAPI.Models;
using Microsoft.Extensions.Configuration;

/*MEGANG-384
usuario: usuarioTiendaDB
pass
t2A3ix71APgK.*/

namespace PrimeraAPI.Data
{
    public class ProductoService
    {
        private readonly string _connectionString;

        public ProductoService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("TiendaDB") ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'TiendaDB'.");
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
        public async Task<Producto> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "SELECT * FROM Productos WHERE Id = @Id", conn
            );

            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Producto
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                };
            }
            return null;
        }

        //Crear un nuevo producto
        public async Task<Producto> CreateAsync(Producto producto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "INSERT INTO productos (Nombre, Precio) OUTPUT INSERTED.Id VALUES(@Nombre, @Precio)", conn
            );

            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            var id = (int)await cmd.ExecuteScalarAsync()!;

            producto.Id = id;
            return producto;
        }

        //Actualizar producto ya existente
        public async Task<bool> UpdateAsync(int id, Producto product)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand(
                "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio WHERE Id = @Id", conn
            );

            cmd.Parameters.AddWithValue("@Nombre", product.Nombre);
            cmd.Parameters.AddWithValue("@Precio", product.Precio);
            cmd.Parameters.AddWithValue("@Id", id);
            var afectedRows = await cmd.ExecuteNonQueryAsync();

            return afectedRows > 0;

        }

        // Eliminar producto por Id
        public async Task<bool> DeleteAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("DELETE FROM Productos WHERE Id = @Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            var affectedRows = await cmd.ExecuteNonQueryAsync();
            
            return affectedRows > 0;
        }

    }
}