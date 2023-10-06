namespace tl2_tp07_2023_VelizMiguelC;
using System.Linq;
using Microsoft.VisualBasic;
public class ManejoDeTareas
{
    private AccesoADatos accesoADatos;
    public ManejoDeTareas(AccesoADatos AccesoADatos){
        accesoADatos = AccesoADatos;
    }
    public bool CrearTarea(Tarea T){
        if (T!=null)
        {
            var Tareas=accesoADatos.ObtenerTarea();
            int idNuevo = Tareas.Count();
            T.Id=idNuevo;
            Tareas.Add(T);
            accesoADatos.GuardarTarea(Tareas);
            return true;
        }
        return false;
    }
    public Tarea ObtenerTareaID(int idTarea){
        var Tareas = accesoADatos.ObtenerTarea();
        var T = Tareas.FirstOrDefault(T => T.Id == idTarea);
        return T;
    }
    public bool UpdateTarea(Estado estado,int idTarea ){
        var Tareas = accesoADatos.ObtenerTarea();
        var T = Tareas.FirstOrDefault(T => T.Id == idTarea);
        if (T != null)
        {
            T.Estados=estado;
            accesoADatos.GuardarTarea(Tareas);
            return true;
        }
        return false;
    }
    public bool DeleteTarea(int idTarea){
        var Tareas = accesoADatos.ObtenerTarea();
        var T = Tareas.FirstOrDefault(T => T.Id == idTarea);
        Tareas.Remove(T);
        T = Tareas.FirstOrDefault(T => T.Id == idTarea);
        if (T != null)
        {
            return false;
        }  
        accesoADatos.GuardarTarea(Tareas);
        return true;
    }
    public List<Tarea> GetListTareas(){
        var Tareas = accesoADatos.ObtenerTarea();
        return Tareas;
    }
    public List<Tarea> GetListTareasCompleted(){
        var Tareas = accesoADatos.ObtenerTarea().FindAll(T => T.Estados == Estado.Copmletada);
        return Tareas;
    }
}