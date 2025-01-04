using API_KanbanBoard.Context;
using API_KanbanBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API_KanbanBoard.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class ColumnaController : ControllerBase
    {
        private AppDbContext _context;

        public ColumnaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Columna> GetColumnas()
        {
            var columnas = _context.Columnas.ToList();
            if (!columnas.Any())
            {
                NotFound("No hay columnas definidas");
            }
            return Ok(columnas);
        }

    }
}
