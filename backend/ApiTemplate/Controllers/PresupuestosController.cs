using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresupuestosController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Create([FromBody] object dto)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    [HttpPatch("{id}/estado")]
    public IActionResult UpdateEstado(int id, [FromBody] object dto)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }

    [HttpGet("cliente/{clienteId}")]
    public IActionResult GetByClienteId(int clienteId)
    {
        // TODO: Implementar
        throw new NotImplementedException();
    }
}
