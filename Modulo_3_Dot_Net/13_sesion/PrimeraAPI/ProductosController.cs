
using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Models;
using PrimeraAPI.Data;

namespace PrimeraAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]  //Api/productos


    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}[controller]")]  //Api/productos

    public class ProductosController: ControllerBase
    {

        //SELECT ...
        private readonly ProductoService _service;
        public ProductosController(ProductoService service)
        {
            _service = service;
        }

        //[Authoprized]
        [HttpGet] // /api/productos //Get
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }


        //[Authoprized]
        [HttpGet("{id}")] //GET // /api/productos/1        
        public async Task<ActionResult<Producto>>  GetById(int id)
        {
            var producto = await _service.GetByIdAsync(id);
            return producto == null ? NotFound() : producto;            
        }


        //--CREATE--POST

        //[Authoprized]
        [HttpPost] //Post  /api/productos
        public async Task<ActionResult<Producto>> Create(Producto nuevo)
        {
            var created = await _service.CreateProductoAsync(nuevo);
            //return producto == null ? NotFound() : producto;            
            //return producto;
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created );
        }


        //--UPDATE--        
        //[Authoprized]
        [HttpPut("{id}")] //PUT /api/productos/1
        public async Task<IActionResult>  Update(int id, Producto actualizado)
        {
            var resultado = await _service.UpdateProductoAsync(id, actualizado);
            return !resultado  ? NotFound() : Ok();                        
        }


        //--DELETE--        
        //[Authoprized]
        [HttpDelete("{id}")] //DELETE /api/productos/1
        public async Task<IActionResult>  Delete(int id)
        {
            var resultado = await _service.DeleteProductoAsync(id);
            return !resultado  ? NotFound() : Ok();                        

        }

     

    }




 }

