using API.Db;
using API.Mapper;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacasController : ControllerBase
    {
        readonly ApiDbContext _dbContext;
        readonly IMapper _mapper;

        public PlacasController(ApiDbContext db, AutoMapperService mapper)
        {
            _dbContext = db;
            _mapper = mapper.Mapper;
        }

        // GET: api/<PlacasController>
        [HttpGet]
        public IActionResult Get(string cedula)
        {
            var propietario = _dbContext.Propietarios.Where(x => x.Cedula == cedula).Include(x => x.Placas).ThenInclude(x => x.Vehiculo).FirstOrDefault();
            
            if (propietario is null)
            {
                return BadRequest("Propietario no encontrado");
            }

            var resultado = _mapper.Map<Propietario, ConsultaDePlaca>(propietario);

            return Ok(resultado);
        }

        // POST api/<PlacasController>
        [HttpPost]
        public void Post([FromBody] RegistroDePlaca registro)
        {
            var propietario = _mapper.Map<RegistroDePlaca, Propietario>(registro);

            _dbContext.Propietarios.Add(propietario);

            var vehiculo = _mapper.Map<RegistroDePlaca, Vehiculo>(registro);

            _dbContext.Vehiculos.Add(vehiculo);

            var placa = _mapper.Map<RegistroDePlaca,  Placa>(registro);
            _dbContext.Placas.Add(placa);

            _dbContext.SaveChanges();
        }
    }
}
