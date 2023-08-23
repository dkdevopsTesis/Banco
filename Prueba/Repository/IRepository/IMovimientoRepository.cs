using Prueba.DTO;
using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface IMovimientoRepository
    {


        Task<MovimientoDto> Register(MovimientoDto movimientoDto);
        public List<Movimiento> GetByClienteAndDateRange(int clienteId, DateTime fechaInicio, DateTime fechaFin);
    }
}
