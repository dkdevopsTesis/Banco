using Azure;
using Microsoft.AspNetCore.Mvc;
using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository.IRepository;
using Prueba.Service;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {

        private readonly IMovimientoRepository _moviminetoRepo;
        private readonly MovimientoService _movimientoService;
        protected APIResponse _response;
        public MovimientoController(IMovimientoRepository movimientoRepo, MovimientoService movimientoService)
        {
            _moviminetoRepo = movimientoRepo;
            _movimientoService= movimientoService;
            _response = new();
        }


        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] MovimientoDto movimientoDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var movimiento = await _moviminetoRepo.Register(movimientoDto);
            if (movimiento == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(movimiento);
        }


        [HttpGet("report")]
        public IActionResult GenerarReporte(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            var reporte = _movimientoService.ObtenerMovimientosPorClienteYRangoFechas(clienteId, fechaInicio, fechaFin);
          
            if (reporte == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while procesing");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(reporte);
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
