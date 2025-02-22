using API_KanbanBoard.Context;
using API_KanbanBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API_KanbanBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColumnaController : ControllerBase
    {
        private AppDbContext _context;

        public ColumnaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Columna> GetColumna()
        {
            var columnas = _context.Columnas.Include(c => c.Tareas)
                                            .ToList();
            if (!columnas.Any())
            {
                NotFound("No hay columnas definidas");
            }
            return Ok(columnas);
        }

    }
}
