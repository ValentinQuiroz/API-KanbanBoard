namespace API_KanbanBoard.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int ColumnaId { get; set; }

        public Tarea()
        {
            
        }
        public Tarea(int _Id, string _Titulo, string _Descripcion, int _ColumnaId)
        {
            Id = _Id;
            Titulo = _Titulo;
            Descripcion = _Descripcion;
            ColumnaId = _ColumnaId;
        }
    }

}
