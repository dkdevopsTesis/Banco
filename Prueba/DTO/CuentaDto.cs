using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class CuentaDto
    {

        public int ClienteId { get; set; }


        [Required(ErrorMessage = "El número de cuenta es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El número de cuenta debe tener 6 caracteres.")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "El tipo de cuenta es obligatorio.")]
        [EnumDataType(typeof(TipoCuenta), ErrorMessage = "El tipo de cuenta debe ser 'Corriente' o 'Ahorro'.")]
        public string TipoCuenta { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El saldo inicial debe ser mayor o igual a cero.")]
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }

    public enum TipoCuenta
    {
        [Display(Name = "Corriente")]
        Corriente,

        [Display(Name = "Ahorro")]
        Ahorro
    }
}
