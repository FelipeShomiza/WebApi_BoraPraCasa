using Microsoft.AspNetCore.Mvc;
using CorridaAPI.Repositories;
using System.Threading.Tasks;
using CorridaAPI.Models;

namespace CorridaAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CorridaController : ControllerBase {
        private readonly ICorridaRepository _corridaRepository;

        public CorridaController(ICorridaRepository corridaRepository) {
            _corridaRepository = corridaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var corridas = await _corridaRepository.GetAllAsync();
            return Ok(corridas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var corrida = await _corridaRepository.GetByIdAsync(id);
            if (corrida == null)
                return NotFound();
            return Ok(corrida);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Corrida corrida) {
            corrida.CalcularValor(); // Supondo que Corrida tem um método CalcularValor()
            await _corridaRepository.AddAsync(corrida);
            return CreatedAtAction(nameof(GetById), new { id = corrida.Id }, corrida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Corrida corrida) {
            if (id != corrida.Id)
                return BadRequest();
            await _corridaRepository.UpdateAsync(corrida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var corrida = await _corridaRepository.GetByIdAsync(id);
            if (corrida == null)
                return NotFound();
            await _corridaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
