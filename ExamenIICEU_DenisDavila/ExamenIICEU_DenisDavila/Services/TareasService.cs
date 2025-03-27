using Microsoft.EntityFrameworkCore;
using AppWebAPI.Data;
using AppWebAPI.Models;

namespace AppWebAPI.Services;

public class TareasService
{
    private readonly DataContext _context;

    public TareasService(DataContext context)
    {
        _context = context;
    }

    //obtener todas las tareas
    public async Task<List<Tareas>> ObtenerTareas()
    {
        return await _context.Tareas.ToListAsync();
    }
    
    //crear una tarea 
    public async Task<Tareas> CrearTarea(Tareas tareas )
    {
        tareas.Id = Guid.NewGuid();
        tareas.CreatedAt = DateTime.UtcNow;

        _context.Tareas.Add(tareas);
        await _context.SaveChangesAsync();
        
        return tareas;
    }
    
    //actualizar una tarea
    public async Task<bool> ActualizarTarea(Guid id, Tareas tareaActualizado)
    {
        var tareas = await _context.Tareas.FindAsync(id);
        if (tareas == null) return false;

        tareas.NombreTarea = tareaActualizado.NombreTarea;
        tareas.Descripcion = tareaActualizado.Descripcion;

        await _context.SaveChangesAsync();
        return true;
    }
    
    //eliminar una tarea
    public async Task<bool> EliminarTarea(Guid id)
    {
        var tareas = await _context.Tareas.FindAsync(id);
        if (tareas == null) return false;

        _context.Tareas.Remove(tareas);
        await _context.SaveChangesAsync();
        return true;
    } 
}