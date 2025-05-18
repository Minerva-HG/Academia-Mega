using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Versioning;
using PrimeraAPI.Models;
using PrimeraAPI.Data;

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

        [HttpGet] // GET api/productos
        public async Task<IActionResult> GetAll()
        {
            var lista = await _service.GetAllAsync();

            return Ok(lista);
        }

    }
}