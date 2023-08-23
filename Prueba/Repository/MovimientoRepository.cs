using Microsoft.EntityFrameworkCore;
using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {


        private readonly ApplicationDbContext _db;
        private readonly ICuentaRepository _cuentaRepo;
      

        public MovimientoRepository(ApplicationDbContext db, ICuentaRepository cuentaRepo)
        {
            _db = db;
            _cuentaRepo = cuentaRepo;
        }

        public async Task<MovimientoDto> Register(MovimientoDto movimientoDto)
        {
     
            var cuentaEncontrado = _cuentaRepo.ObtenerPorNumeroCuenta(movimientoDto.NumeroCuenta);
            if (cuentaEncontrado != null)
            {

                if (cuentaEncontrado == null)
                {
                    throw new Exception("Cuenta no encontrada");
                }

                if (movimientoDto.TipoMovimiento == "Crédito")
                {
                    cuentaEncontrado.SaldoInicial += movimientoDto.Valor;
                }
                else if (movimientoDto.TipoMovimiento == "Débito")
                {
                    if (cuentaEncontrado.SaldoInicial < movimientoDto.Valor)
                    {
                        throw new Exception("Saldo no disponible");
                    }
                    cuentaEncontrado.SaldoInicial -= movimientoDto.Valor;
                }
                var nuevoMovimiento = new Movimiento
                {
                    TipoMovimiento = movimientoDto.TipoMovimiento,
                    Saldo = cuentaEncontrado.SaldoInicial,
                    Valor = movimientoDto.Valor,
                    Cuenta = cuentaEncontrado,
                    Fecha = DateTime.Now,
                    
                };
                _db.Movimientos.Add(nuevoMovimiento);
                _cuentaRepo.Update(cuentaEncontrado);
                await _db.SaveChangesAsync();
            }
          
            return movimientoDto;
        }

        public List<Movimiento> GetByClienteAndDateRange(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            return _db.Movimientos
                .Where(m => m.Cuenta.ClienteId == clienteId && m.Fecha >= fechaInicio && m.Fecha <= fechaFin)
                .ToList();
        }
    }
}
