using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductosController : ControllerBase
{ 
    
    /// Aqui seria la lectura  de datos
    
    public static readonly List<Producto> _datos = new List<Producto>
    {
        new Producto { id = 1 , Nombre = "iphone 16", Precio = 20000.0m},
        new Producto { id = 2 , Nombre = "Galaxy S25 Edge" , Precio= 20000.0m}
    };



    /*
        - CREATE
    */
    [HttpPost] //POST / api/ productos
    public ActionResult<Producto> Create(Producto nuevo)
    {
        nuevo.id = _datos.Max(p => p.id) + 1;
        _datos.Add(nuevo);
        return CreatedAtAction(nameof(GetById) new{id = nuevo.id});
    }
    
    /*
        - READ
    */

    [HttpPut("{id}")]

    public IActionResult Update (int id, Producto actualizado)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        product.Nombre = actualizado.Nombre;
        product.Precio = actualizado.Precio;

        return NoContent();
    }

    //Delete
    [HttpDelete("{id}")]
    public IActionResult Delete (int id)
    {
        var product = _datos.FirstOrDefault(p => p.id == id);
        if (product == null) return NotFound();

        _datos.Remove(product);
        return NoContent("El valor se ha elimiando correctamente");

    }







    [HttpGet] // /api/productos
    public ActionResult<IEnumerable<Producto>> GetAll()
    {
        return Ok(_datos);
    }

    [HttpGet("{id}")]

    public  ActionResult<Producto> GetById(int id)
    {
        var product =  _datos.FirstOrDefault(p=> p.id == id);
        if (product == null) return NotFound();
        return ok(product);
    }

}

//Modelo producto
public class Producto()
{
    public int id {get; set;}    

    public string Nombre{get; set;} = string.Empty;

    public decimal Precio {get; set;} 
}