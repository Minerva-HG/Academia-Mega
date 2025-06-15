using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Versioning;
using PrimeraAPI.Models;
using PrimeraAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace PrimeraAPI.controllers
{
    [ApiController]
    //[ApiVersion("1.0")] v{version:apiVersion}/
    [Route("api/[controller]")] // api/v1

    public class ProductosController : ControllerBase
    {
        //Aquí sería la dectura de datos en BD
        private readonly ProductoService _service;
        public ProductosController(ProductoService service)
        {
            _service = service;
        }


        /*
            - READ -
        */

        [Authorize]
        [HttpGet] // GET api/productos
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();

            return Ok(lista);
        }

        [Authorize]
        [HttpGet("{id}")] // GET api/productos/1
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null) return NotFound();
            return Ok(product);
        }

        /*
            - CREATE -
        */

        [Authorize]
        [HttpPost]  // POST api/productos
        public async Task<IActionResult> Create(Producto nuevo)
        {
            var created = await _service.CreateAsync(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        /*
            - UPDATE -
        */

        [Authorize]
        [HttpPut("{id}")] // PUT api/productos/1
        public async Task<IActionResult> Update(int id, Producto actualizado)
        {
            var updated = await _service.UpdateAsync(id, actualizado);
            if (!updated) return NotFound();
            return NoContent();
        }

        /*
            - DELETE -
        */

        [Authorize]
        [HttpDelete("{id}")] // DELETE api/productos/1
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}