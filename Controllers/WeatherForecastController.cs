using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_VelizMiguelC.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{

    private readonly ILogger<TareaController> _logger;
    private ManejoDeTareas tareamanejo;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        var accesoADatos=new AccesoADatos();
        tareamanejo = new ManejoDeTareas(accesoADatos);
    }

    [HttpGet]
    [Route("Lista Tareas")]
    public ActionResult <string> GetListTareas(){
        var Tareas= tareamanejo.GetListTareas();
        if (Tareas != null)
        {
            return Ok(Tareas);
        }
        return BadRequest();
    }
    [HttpGet]
    [Route("Lista De Tareas completadas")]
    public ActionResult <string> GetListTareasCompleted(){
        var Ts = tareamanejo.GetListTareasCompleted();
        if (Ts != null)
        {
            return Ok(Ts);
        }
        return BadRequest();
    }
    [HttpGet]
    [Route("Tarea/{idTarea}")]
    public ActionResult <string> GetTarea(int idTarea){
        var T = tareamanejo.ObtenerTareaID(idTarea);
        if (T != null)
        {
            return Ok(T);
        }
        return BadRequest("Envie bien");
    }
    [HttpPost("addTarea")]
    public ActionResult <string> CrearTarea(Tarea T){
        bool Exito = tareamanejo.CrearTarea(T);
        if (Exito)
        {
            return Ok();
        }
        
        return BadRequest("Envie bien");
    }
    [HttpPut("UpdateTarea")]
    public ActionResult <string> UpdateTarea(Estado estado, int idTarea){
        var Exito = tareamanejo.UpdateTarea(estado,idTarea);
        if (Exito)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpDelete("EliminarTarea")]
    public ActionResult <string> DeleteTarea(int idTarea){
        var Exito = tareamanejo.DeleteTarea(idTarea);
        if (Exito)
            {
                return Ok();
            }
        return BadRequest();
    }
}
