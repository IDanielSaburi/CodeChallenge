using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;

[Route("api/[controller]")]
[ApiController]
public class MotorcycleController : ControllerBase
{
    private readonly IMotorcycleRepository _motorcycleRepository;

    public MotorcycleController(IMotorcycleRepository motorcycleRepository)
    {
        _motorcycleRepository = motorcycleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Motorcycle>>> GetAllMotorcycles()
    {
        var motorcycles = await _motorcycleRepository.GetAllAsync();
        return Ok(motorcycles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Motorcycle>> GetMotorcycle(int id)
    {
        var motorcycle = await _motorcycleRepository.GetByIdAsync(id);

        if (motorcycle == null)
        {
            return NotFound();
        }

        return Ok(motorcycle);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMotorcycle([FromBody] Motorcycle motorcycle)
    {
        await _motorcycleRepository.AddAsync(motorcycle);
        return CreatedAtAction(nameof(GetMotorcycle), new { id = motorcycle.Id }, motorcycle);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMotorcycle(int id, [FromBody] Motorcycle motorcycle)
    {
        if (id != motorcycle.Id)
        {
            return BadRequest();
        }

        await _motorcycleRepository.UpdateAsync(motorcycle);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMotorcycle(int id)
    {
        var motorcycleToDelete = await _motorcycleRepository.GetByIdAsync(id);
        if (motorcycleToDelete == null)
        {
            return NotFound();
        }

        await _motorcycleRepository.DeleteAsync(motorcycleToDelete);
        return NoContent();
    }
}
