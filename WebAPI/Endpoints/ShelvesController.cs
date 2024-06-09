using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ShelvesController : ControllerBase
{
    private readonly IShelfService _shelfService;
    public ShelvesController(IShelfService shelfService)
    {
        _shelfService = shelfService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var shelves = await _shelfService.GetAllAsync();
        return Ok(shelves);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var shelf = await _shelfService.GetByIdAsync(id);
        if (shelf == null) return NotFound();
        return Ok(shelf);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShelfDto dto)
    {
        await _shelfService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateShelfDto dto)
    {
        await _shelfService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _shelfService.DeleteAsync(id);
        return NoContent();

    }
}