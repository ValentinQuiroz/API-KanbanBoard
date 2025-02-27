﻿using API_KanbanBoard.Context;
using API_KanbanBoard.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_KanbanBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                return NotFound("No hay tareas definidas.");
            }
            return Ok(tareas);
        }

        [HttpPost]
        public ActionResult<Tarea> PostTarea(Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("La tarea no puede ser null.");
            }

            if (_context.Tareas.Any(t => t.Titulo.Trim() == tarea.Titulo.Trim() ))
            {
                return Conflict("Ya existe una tarea con ese título.");
            }

            if(tarea.Titulo.Length < 5 || tarea.Titulo.Length > 50)
            {
                return BadRequest("El título debe tener entre 5 y 50 caracteres.");
            } 

            _context.Tareas.Add(tarea);
            _context.SaveChanges();
            return CreatedAtAction("GetTarea", new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]

        public ActionResult<Tarea> PutTarea(int id, Tarea tarea)
        {
            if (tarea == null || tarea.Id != id)
            {
                return BadRequest("Error en los datos.");
            }

            var tareaToUpdate = _context.Tareas.Find(id);
            if (tareaToUpdate == null)
            {
                return NotFound("Tarea no encontrada.");
            }
            tareaToUpdate.Titulo = tarea.Titulo;
            tareaToUpdate.Descripcion = tarea.Descripcion;
            tareaToUpdate.ColumnaId = tarea.ColumnaId;

            _context.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]

        public ActionResult<Tarea> PatchTarea(int id, [FromBody] int nuevaColumnaId)
        {
            var tareaToPatch = _context.Tareas.Find(id);
            if(tareaToPatch == null)
            {
                return NotFound("Tarea no encontrada.");
            }


            tareaToPatch.ColumnaId = nuevaColumnaId;
            _context.SaveChanges();

            return Ok(tareaToPatch);
        }

        [HttpDelete("{id}")]
        public ActionResult<Tarea> DeleteTarea(int id)
        {
            var tareaToDelete = _context.Tareas.Find(id);
            if (tareaToDelete == null)
            {
                return NotFound("Tarea no encontrada.");
            }

            _context.Tareas.Remove(tareaToDelete);
            _context.SaveChanges();

            return NoContent(); 
        }


    }
}
