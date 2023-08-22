using Azure;
using Microsoft.AspNetCore.Mvc;
using Prueba.DTO;
using Prueba.Repository.IRepository;
using System.Net;
using System.Security.Cryptography;

namespace Prueba.Controllers
{
    public class CuentaController : Controller
    {

        private readonly ICuentaRepository _cuentaRepo;
        protected APIResponse _response;
        public CuentaController(ICuentaRepository cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
            _response = new();
        }



        // POST api/<ClienteController>
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CuentaDto cuentaDto)
        {

            var client = await _cuentaRepo.RegistrarCuenta(cuentaDto);
            if (client == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
