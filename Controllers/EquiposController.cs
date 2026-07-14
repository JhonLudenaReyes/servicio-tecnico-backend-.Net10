using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servicio_tecnico_backend.Models.Entities;
using servicio_tecnico_backend.Services.Interfaces;

namespace servicio_tecnico_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipoService _equiposService;

        public EquiposController(IEquipoService equiposService)
        {
            _equiposService = equiposService;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetAll()
        {
            var equipos = await _equiposService.GetAllAsync();
            return Ok(equipos);
        }

        [HttpGet("equipo/buscar/{id}")]
        public async Task<ActionResult<Equipo>> GetById(int id)
        {
            var equipo = await _equiposService.GetByIdAsync(id);
            if (equipo == null) return NotFound();
            return Ok(equipo);
        }

        [HttpPost("equipo/guardar")]
        public async Task<ActionResult<Equipo>> Create(Equipo equipo)
        {
            var createdEquipo = await _equiposService.CreateAsync(equipo);
            return CreatedAtAction(nameof(GetById), new { id = createdEquipo.IdEquipo }, createdEquipo);
        }

        [HttpPut("equipo/actualizar/{id}")]
        public async Task<IActionResult> Update(int id, Equipo equipo)
        {
            var result = await _equiposService.UpdateAsync(id, equipo);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("equipo/eliminar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _equiposService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
