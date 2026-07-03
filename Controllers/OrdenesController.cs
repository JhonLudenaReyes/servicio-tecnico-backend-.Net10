using Microsoft.AspNetCore.Mvc;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesController : ControllerBase
{
    private readonly IOrdenService _ordenService;

    public OrdenesController(IOrdenService ordenService)
    {
        _ordenService = ordenService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orden>>> GetAll()
    {
        var ordenes = await _ordenService.GetAllAsync();
        return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Orden>> GetById(int id)
    {
        var orden = await _ordenService.GetByIdAsync(id);
        if (orden == null) return NotFound();
        return Ok(orden);
    }

    [HttpGet("cliente/{idPersona}")]
    public async Task<ActionResult<IEnumerable<Orden>>> GetByCliente(int idPersona)
    {
        var ordenes = await _ordenService.GetByClienteAsync(idPersona);
        return Ok(ordenes);
    }

    [HttpGet("estado/{idEstado}")]
    public async Task<ActionResult<IEnumerable<Orden>>> GetByEstado(int idEstado)
    {
        var ordenes = await _ordenService.GetByEstadoAsync(idEstado);
        return Ok(ordenes);
    }

    [HttpPost]
    public async Task<ActionResult<Orden>> Create(Orden orden)
    {
        var createdOrden = await _ordenService.CreateAsync(orden);
        return CreatedAtAction(nameof(GetById), new { id = createdOrden.IdOrden }, createdOrden);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Orden orden)
    {
        var result = await _ordenService.UpdateAsync(id, orden);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _ordenService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
