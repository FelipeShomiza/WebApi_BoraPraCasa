using Microsoft.AspNetCore.Mvc;
using CorridaAPI.Models;
using CorridaAPI.Repositories;

namespace CorridaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CorridaController : ControllerBase
{
    private readonly ICorridaRepository _repository;

    public CorridaController(ICorridaRepository repository)
    {
        _repository = repository;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Corrida>>> GetCorridas()
    {
        return Ok(await _repository.GetAllAsync());
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<Corrida>> GetCorrida(int id)
    {
        var corrida = await _repository.GetByIdAsync(id);
        if (corrida == null) return NotFound();
        return Ok(corrida);
    }

    
    [HttpPost]
    public async Task<ActionResult<Corrida>> PostCorrida(Corrida corrida)
    {
        corrida.AtualizarValor(); 
        await _repository.AddAsync(corrida);
        if (corrida.Distancia <= 0) return BadRequest("A distância deve ser maior que zero.");
        return CreatedAtAction(nameof(GetCorrida), new { id = corrida.Id }, corrida);
        
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCorrida(int id, Corrida corrida)
    {
        if (id != corrida.Id) return BadRequest();
        
        corrida.AtualizarValor();
        await _repository.UpdateAsync(corrida);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCorrida(int id)
    {
        var corrida = await _repository.GetByIdAsync(id);
        if (corrida == null) return NotFound();


        await _repository.DeleteAsync(id); 
        return NoContent();
    }
}