using Microsoft.AspNetCore.Mvc;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CiudadesController : ControllerBase
{
    private readonly ICiudadService _ciudadService;

    public CiudadesController(ICiudadService ciudadService)
    {
        _ciudadService = ciudadService;
    }

    [HttpGet("listado")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetAll()
    {
        var ciudades = await _ciudadService.GetAllAsync();
        return Ok(ciudades);
    }

    [HttpGet("ciudad/buscar/{id}")]
    public async Task<ActionResult<Ciudad>> GetById(int id)
    {
        var ciudad = await _ciudadService.GetByIdAsync(id);
        if (ciudad == null) return NotFound();
        return Ok(ciudad);
    }

    [HttpPost("ciudad/guardar")]
    public async Task<ActionResult<Ciudad>> Create(Ciudad ciudad)
    {
        var createdCiudad = await _ciudadService.CreateAsync(ciudad);
        return CreatedAtAction(nameof(GetById), new { id = createdCiudad.IdCiudad }, createdCiudad);
    }

    [HttpPut("ciudad/actualizar/{id}")]
    public async Task<IActionResult> Update(int id, Ciudad ciudad)
    {
        var result = await _ciudadService.UpdateAsync(id, ciudad);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("ciudad/eliminar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _ciudadService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
