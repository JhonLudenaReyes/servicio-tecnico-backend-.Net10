using Microsoft.AspNetCore.Mvc;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiposController : ControllerBase
{
    private readonly ITipoService _tipoService;

    public TiposController(ITipoService tipoService)
    {
        _tipoService = tipoService;
    }

    [HttpGet("listado")]
    public async Task<ActionResult<IEnumerable<Tipo>>> GetAll()
    {
        var tipos = await _tipoService.GetAllAsync();
        return Ok(tipos);
    }

    [HttpGet("tipo/buscar/{id}")]
    public async Task<ActionResult<Tipo>> GetById(int id)
    {
        var tipo = await _tipoService.GetByIdAsync(id);
        if (tipo == null) return NotFound();
        return Ok(tipo);
    }

    [HttpPost("tipo/guardar")]
    public async Task<ActionResult<Tipo>> Create(Tipo tipo)
    {
        var created = await _tipoService.CreateAsync(tipo);
        return CreatedAtAction(nameof(GetById), new { id = created.IdTipo }, created);
    }

    [HttpPut("tipo/actualizar/{id}")]
    public async Task<IActionResult> Update(int id, Tipo tipo)
    {
        var result = await _tipoService.UpdateAsync(id, tipo);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("tipo/eliminar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _tipoService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
