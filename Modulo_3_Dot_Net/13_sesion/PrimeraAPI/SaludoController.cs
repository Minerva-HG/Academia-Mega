using Microsoft.AspNetCore.Mvc;

//Notaciones ->

[ApiController]
[Route("[controller]")]
public class SaludoController : ControllerBase
{
    //Get para saludo
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { mensaje = "Hola desde el SaludoController" } );
    }

    //GET /saludo/{name}
    [HttpGet("personalizado/{name}")]
    public IActionResult GetPersonalizado(string name )
    {
        var response = new
        {
            mensaje = $"Hola , {name}"
        };

        return Ok(response);

    }

    

}

