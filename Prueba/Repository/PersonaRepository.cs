using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly ApplicationDbContext _db;


        public PersonaRepository(ApplicationDbContext db)
        {
            _db = db;
      
        }

        public Cliente GetById(int id)
        {
            return _db.Clientes.SingleOrDefault(x => x.PersonaId == id);

        }
        public async Task<ClienteDto> Register(ClienteDto clienteDto)
        {
            var nuevoCliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Genero = clienteDto.Genero,
                Edad = clienteDto.Edad,
                Identificacion = clienteDto.Identificacion,
                Direccion = clienteDto.Direccion,
                Telefono = clienteDto.Telefono,
                Contraseña = clienteDto.Contraseña,
                Estado = clienteDto.Estado
            };


            _db.Personas.Add(nuevoCliente);
            await _db.SaveChangesAsync();

            return clienteDto;
        }


    }
}
