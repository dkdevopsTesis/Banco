using Prueba.DTO;
using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface ICuentaRepository
    {

        Task<CuentaDto> RegistrarCuenta(CuentaDto cuenta);
    }
}
