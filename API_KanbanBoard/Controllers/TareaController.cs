using API_KanbanBoard.Context;
using API_KanbanBoard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API_KanbanBoard.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class TareaController : ControllerBase
    {
        private AppDbContext _context;

        public TareaController(AppDbContext context) 
        {
             _context = context;
        }

        [HttpGet]
        public ActionResult<Tarea> GetTarea()
        {
            var tareas = _context.Tareas.ToList();
            if (!tareas.Any())
            {
                NotFound("No hay tareas definidas");
            }
            return Ok(tareas);
        }

        [HttpPost]
        public ActionResult<Tarea> PostTarea(Tarea tarea)
        {
            if(tarea == null)
            {
                return BadRequest("La tarea no puede ser null");
            }

            _context.Tareas.Add(tarea);
            _context.SaveChanges();
            return CreatedAtAction("GetTarea", new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]

        public ActionResult<Tarea> PutTarea(int id, Tarea tarea)
        {
            if(tarea == null ||tarea.Id != id)
            {
                return BadRequest("Error en los datos");
            }

            var TareaToUpdate = _context.Tareas.FirstOrDefault(t => t.Id == id);
            if(TareaToUpdate == null)
            {
                return NotFound("Tarea no encontrada");
            }
            TareaToUpdate.Titulo = tarea.Titulo;
            TareaToUpdate.Descripcion = tarea.Descripcion;
            TareaToUpdate.ColumnaId = tarea.ColumnaId;

            _context.SaveChanges();

            return NoContent();

        }

    }
}
