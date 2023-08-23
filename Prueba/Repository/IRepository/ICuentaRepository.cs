using Prueba.DTO;
using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface ICuentaRepository
    {

        Task<CuentaDto> RegistrarCuenta(CuentaDto cuenta);
        public Cuenta ObtenerPorNumeroCuenta(string numeroCuenta);
        public void Update(Cuenta entidad);
    }
}
