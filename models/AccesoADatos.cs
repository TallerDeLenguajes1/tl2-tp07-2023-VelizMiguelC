namespace tl2_tp07_2023_VelizMiguelC;
using System.Text.Json;

public class AccesoADatos
{
    public List<Tarea> ObtenerTarea(){
        List<Tarea> Tareas = null;
        if (File.Exists("Tareas.json"))
        {
            string json = File.ReadAllText("Tareas.json");
            Tareas = JsonSerializer.Deserialize<List<Tarea>>(json);
        }else
        {
            System.Console.WriteLine("No existe Tareas.json");
        }
        return Tareas;
    }
    public void GuardarTarea(List<Tarea> T){
        string json = JsonSerializer.Serialize(T);
        File.WriteAllText("Tareas.json",json);
    }
}
