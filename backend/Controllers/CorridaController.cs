using Microsoft.AspNetCore.Mvc;
using CorridaAPI.Repositories;
using CorridaAPI.Models;

namespace CorridaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorridaController : ControllerBase
    {
        private readonly ICorridaRepository _corridaRepository;

        public CorridaController(ICorridaRepository corridaRepository)
        {
            _corridaRepository = corridaRepository;
        }

        // GET: api/Corrida
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var corridas = await _corridaRepository.GetAllAsync();
            return Ok(corridas);
        }

        // GET: api/Corrida/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var corrida = await _corridaRepository.GetByIdAsync(id);

            if (corrida == null)
                return NotFound("Corrida não encontrada.");

            return Ok(corrida);
        }

        // POST: api/Corrida
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Corrida corrida)
        {
            if (corrida == null)
                return BadRequest("Dados inválidos.");

            corrida.CalcularValor();

            await _corridaRepository.AddAsync(corrida);

            return CreatedAtAction(
                nameof(GetById),
                new { id = corrida.Id },
                corrida
            );
        }

        // PUT: api/Corrida/1
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] Corrida corridaAtualizada)
{
    if (corridaAtualizada == null)
        return BadRequest("Dados inválidos.");

    if (id != corridaAtualizada.Id)
        return BadRequest("O ID da URL é diferente do ID da corrida.");

    var corridaExistente = await _corridaRepository.GetByIdAsync(id);

    if (corridaExistente == null)
        return NotFound("Corrida não encontrada.");

    corridaExistente.Nome = corridaAtualizada.Nome;
    corridaExistente.Distancia = corridaAtualizada.Distancia;

    corridaExistente.CalcularValor();

    await _corridaRepository.UpdateAsync(corridaExistente);

    return NoContent();
}

        // PATCH: api/Corrida/1
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] Corrida corridaAtualizada)
        {
            var corrida = await _corridaRepository.GetByIdAsync(id);

            if (corrida == null)
                return NotFound("Corrida não encontrada.");

            if (!string.IsNullOrWhiteSpace(corridaAtualizada.Nome))
            {
                corrida.Nome = corridaAtualizada.Nome;
            }

            if (corridaAtualizada.Distancia > 0)
            {
                corrida.Distancia = corridaAtualizada.Distancia;
                corrida.CalcularValor();
            }

            await _corridaRepository.UpdateAsync(corrida);

            return Ok(corrida);
        }

        // DELETE: api/Corrida/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var corrida = await _corridaRepository.GetByIdAsync(id);

            if (corrida == null)
                return NotFound("Corrida não encontrada.");

            await _corridaRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}