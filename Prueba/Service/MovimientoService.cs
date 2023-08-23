using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Service
{
    public class MovimientoService
    {

        private readonly IMovimientoRepository _movimientoRepository;


        public MovimientoService(IMovimientoRepository movimientoRepository) { 

            _movimientoRepository = movimientoRepository;
        }

        public ReporteDto ObtenerMovimientosPorClienteYRangoFechas(int clienteId, DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }

            var movimientos = _movimientoRepository.GetByClienteAndDateRange(clienteId, fechaInicio, fechaFin);

            // Cálculo de saldo total, débitos y créditos
            decimal saldoTotal = movimientos.Sum(m => m.Saldo);
            decimal debitos = movimientos.Where(m => m.TipoMovimiento == "Débito").Sum(m => m.Valor);
            decimal creditos = movimientos.Where(m => m.TipoMovimiento == "Crédito").Sum(m => m.Valor);

            var reporte = new ReporteDto
            {
                Movimientos = movimientos,
                SaldoTotal = saldoTotal,
                Debitos = debitos,
                Creditos = creditos
            };
            return reporte;
        }
    }
}
