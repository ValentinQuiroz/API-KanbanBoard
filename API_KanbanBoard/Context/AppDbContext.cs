using API_KanbanBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace API_KanbanBoard.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Columna> Columnas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
    }
}
