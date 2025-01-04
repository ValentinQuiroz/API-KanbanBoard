namespace API_KanbanBoard.Models
{
    public class Columna
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Tarea> Tareas { get; set; }


        public Columna()
        {
            
        }
        public Columna(int _Id, string _Nombre, List<Tarea> _Tareas)
        {
            Id = _Id;
            Nombre = _Nombre;
            Tareas = _Tareas;
        }
    }
}
