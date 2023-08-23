using Azure;
using Microsoft.AspNetCore.Mvc;
using Prueba.DTO;
using Prueba.Repository.IRepository;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IPersonaRepository _personaRepo;
        protected APIResponse _response;
        public ClienteController(IPersonaRepository personaRepo)
        {
            _personaRepo = personaRepo;
            _response = new();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] ClienteDto clienteDto )
        {
            
            var client = await _personaRepo.Register(clienteDto);
            if (client == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(client);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
