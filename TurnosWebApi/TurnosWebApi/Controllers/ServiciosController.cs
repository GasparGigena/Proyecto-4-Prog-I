using Microsoft.AspNetCore.Mvc;
using ServiciosBack.Data;
using ServiciosBack.Data.Models;
using ServiciosBack.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TurnosWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServicioRepository _repository;

        public ServiciosController (IServicioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno !!!");
            }
        }

        [HttpGet("servicio/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!!!!!!!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                var servicioUpdate = _repository.GetById(servicio.Id);
                if (servicioUpdate == null)
                {
                    _repository.Save(servicio);
                    return Ok("Servicio Creado Con Exito!!");
                }
                else
                {
                    _repository.Update(servicio);
                    return Ok("Servicio Actualizado con Exito!!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno");

            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TServicio servicio)
        {
            try
            {
                if (servicio == null)
                {
                    return BadRequest("Porfavor, completar todos los datos");
                }
                var oServicio = _repository.GetById(id);
                if (oServicio == null)
                {
                    return BadRequest("No se pudo encontrar al usuario");
                }
                oServicio.Nombre = servicio.Nombre;
                oServicio.Costo = servicio.Costo;
                oServicio.EnPromocion = servicio.EnPromocion;

                _repository.Update(oServicio);
                return Ok("Servicio actualizado correctamente");
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocurrio un error interno!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var oServicio = _repository.GetById(id);
                if (oServicio == null)
                {
                    return BadRequest("NO se pudo encontrar el servicio");
                }
                _repository.Delete(id);
                return Ok("Servicio eliminado correctamente");
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocurrio un error interno!!!");
            }

        }
    }
}
