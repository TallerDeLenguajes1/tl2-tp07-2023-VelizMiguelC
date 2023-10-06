namespace tl2_tp07_2023_VelizMiguelC;
public enum Estado{
    Pendiente=1,
    EnProgreso=0,
    Copmletada=2
}
public class Tarea
{
    private int id;
    private string titulo;
    private string descripcion;
    private Estado estados;

    public Tarea(int id, string titulo, string descripcion, Estado estados)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Estados = estados;
    }

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Estado Estados { get => estados; set => estados = value; }
}