using Prueba.DTO;
using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface IPersonaRepository
    {



        Task<ClienteDto> Register(ClienteDto clienteDto);
        public Cliente GetById(int id);
    }
}
