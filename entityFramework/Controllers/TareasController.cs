using Microsoft.AspNetCore.Mvc;
namespace entityFramework.Controllers;
using entityFramework.Models;
using entityFramework.Services;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly ITareasService _tareasService;

    public TareasController(ITareasService tareasService)
    {
        _tareasService = tareasService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tareas = _tareasService.Get();
        return Ok(tareas);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarea tarea)
    {
        if (tarea == null)
        {
            return BadRequest("La tarea no puede ser nula.");
        }

        await _tareasService.Save(tarea);
        return CreatedAtAction(nameof(Get), new { id = tarea.TareaId }, tarea);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Tarea tarea)
    {
        if (tarea == null || id != tarea.TareaId)
        {
            return BadRequest("La tarea no puede ser nula y el ID debe coincidir.");
        }

        await _tareasService.Update(id, tarea);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tareasService.Delete(id);
        return NoContent();
    }
}