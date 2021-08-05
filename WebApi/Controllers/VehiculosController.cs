using DatosVehiculo.Model;
using DatosVehiculo.ModelosNuevos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly EjercicioEvaluacionContext _context;

        public VehiculosController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }

        // GET: api/<VehiculosController>
        [Route("ListaVehiculos")]
        [HttpGet]
        public List<Vehiculo>Get()
        {
            return _context.Vehiculo.ToList();
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{id}")]
        public Vehiculo Get(int id)
        {
            Vehiculo vehiculo = _context.Vehiculo.Where(v => v.Codigo == id).FirstOrDefault();
           
            return vehiculo;
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public int Post([FromBody] Vehiculo vehiculo)
        {
            int respuesta = 0;
            try
            {
                _context.Add(vehiculo);
                _context.SaveChanges();
                respuesta = 1;
            }
            catch(Exception)
            {
                respuesta = 0 ;
            }
            return respuesta;
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
