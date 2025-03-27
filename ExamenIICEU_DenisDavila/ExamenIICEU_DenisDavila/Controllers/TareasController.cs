using Microsoft.AspNetCore.Mvc;
using AppWebAPI.Services;
using AppWebAPI.Models;

namespace AppWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TareasController : ControllerBase
{
    private readonly TareasService _tareasService;

    public TareasController(TareasService usuarioService)
    {
        _tareasService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tareas>>> ObtenerTareas()
    {
        var tareas = await _tareasService.ObtenerTareas();
        return Ok(tareas);
    }

    [HttpPost]
    public async Task<ActionResult> CrearTarea([FromBody]Tareas tareas)
    {
        if (tareas == null)
        {
            return BadRequest("Datos de la tarea estan vacios");
        }
        var nuevaTarea = await _tareasService.CrearTarea(tareas);
        return Ok(nuevaTarea);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarTarea(Guid id, [FromBody] Tareas tareaActualizada)
    {
        if (tareaActualizada == null)
        {
            return BadRequest("Datos de la tarea estan vacios");
        }

        var response = await _tareasService.ActualizarTarea(id, tareaActualizada);

        if (response == false)
        {
            return NotFound("Tarea no encontrada en la base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarTarea(Guid id)
    {
        var response = await _tareasService.EliminarTarea(id);
        if (response == false)
        {
            return NotFound("Usuario no encontrado en base de datos");
        }
        return NoContent();
    }
    
}