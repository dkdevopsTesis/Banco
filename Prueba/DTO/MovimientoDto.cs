using System.ComponentModel.DataAnnotations;

namespace Prueba.DTO
{
    public class MovimientoDto
    {

        [Required(ErrorMessage = "El número de cuenta es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El número de cuenta debe tener 6 caracteres.")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "El tipo de movimiento es obligatorio.")]
        [EnumDataType(typeof(TipoCuenta), ErrorMessage = "El tipo de movimiento debe ser 'Débito' o 'Crédito'.")]
        public string TipoMovimiento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser mayor o igual a cero.")]
        public decimal Valor { get; set; }
        public bool Estado { get; set; }
    }


    public enum TipoMovimiento
    {
        [Display(Name = "Débito")]
        Débito,

        [Display(Name = "Crédito")]
        Crédito
    }
}
