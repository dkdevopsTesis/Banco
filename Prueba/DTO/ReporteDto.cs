using Prueba.Model;

namespace Prueba.DTO
{
    public class ReporteDto
    {

        public List<Movimiento> Movimientos { get; set; }
        public decimal SaldoTotal { get; set; }
        public decimal Debitos { get; set; }
        public decimal Creditos { get; set; }
    }
}
