//Producto Service
using System.Data.SqlClient;
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

        //Obtener los productos de la base de datos

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



        //Obtener producto por id
        public async Task<Producto> GetByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand($"SELECT * FROM Productos WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            Producto producto = null;
            if (await reader.ReadAsync())
            {
                producto = new Producto
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Precio = reader.GetDecimal(2)
                };

            }
            return producto;
            
            
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        //public async Task<Producto> CreateProductoAsync(string nombre, decimal precio)
        {            
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd = new SqlCommand("INSERT INTO Productos (Nombre, Precio) OUTPUT INSERTED.Id VALUES (@nombre, @precio)", conn);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            object resultado = await cmd.ExecuteScalarAsync()!;
            //! Anulación de nulos ...

            //producto = new Producto { Id = -1, Nombre = nombre, Precio = precio };
            if (resultado != null)
            {
                producto.Id = Convert.ToInt32(resultado);
            }

            return producto;
        }

        public async Task<bool> UpdateProductoAsync(int id, Producto productoActualizado)
        {
            bool resultado = false;

            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            SqlCommand cmd = new SqlCommand("UPDATE Productos SET Nombre = @Nombre , Precio = @Precio OUTPUT inserted.id WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@Nombre", productoActualizado.Nombre);
            cmd.Parameters.AddWithValue("@Precio", productoActualizado.Precio);
            cmd.Parameters.AddWithValue("@Id", id);
            object res = await cmd.ExecuteScalarAsync();

            if (res != null)
            { 
                  resultado = true;
            }
              

            return resultado;
        }                          
        
     public  async Task<bool> DeleteProductoAsync (int id )
        {
            bool resultado = false;
            using  var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            //SqlCommand cmd = new SqlCommand("DELETE FROM Productos  WHERE Id = @id", conn);            
            SqlCommand cmd = new SqlCommand("DELETE FROM Productos  OUTPUT deleted.Id WHERE Id = @id", conn);            
            cmd.Parameters.AddWithValue("@Id", id);
            //var affectedRows = await cmd.ExecuteNonQueryAsync();

            object res = await cmd.ExecuteScalarAsync();            

            if (res != null)
                resultado = true;            

            return resultado;
        }         

    }

}