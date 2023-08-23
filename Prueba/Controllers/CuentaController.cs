using Azure;
using Microsoft.AspNetCore.Mvc;
using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository;
using Prueba.Repository.IRepository;
using System.Net;
using System.Security.Cryptography;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {

        private readonly ICuentaRepository _cuentaRepo;
        private readonly IPersonaRepository _personaRepo;
        protected APIResponse _response;
        public CuentaController(ICuentaRepository cuentaRepo, IPersonaRepository personaRepo)
        {
            _cuentaRepo = cuentaRepo; 
            _personaRepo = personaRepo;
            _response = new();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CuentaDto cuentaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve errores de validación al cliente
            }
            var cuenta = await _cuentaRepo.RegistrarCuenta(cuentaDto);
            if (cuenta == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(cuenta);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCuenta(int id, [FromBody]  CuentaDto cuenta)
        {
        
            var existingCuenta = _cuentaRepo.ObtenerPorNumeroCuenta(cuenta.NumeroCuenta);
            var persona = _personaRepo.GetById(cuenta.ClienteId);

            if (existingCuenta == null)
            {
                return NotFound();
            }

             existingCuenta.Cliente = persona;
            _cuentaRepo.Update(existingCuenta);
           //await _db.SaveChangesAsync();
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(existingCuenta);
        }
    }
}
