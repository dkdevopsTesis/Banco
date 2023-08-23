using Microsoft.EntityFrameworkCore;
using Prueba.DTO;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class CuentaRepository: ICuentaRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IPersonaRepository _personaRepo;

        public CuentaRepository(ApplicationDbContext db, IPersonaRepository personaRepo)
        {
            _db = db;
            _personaRepo = personaRepo;
        }

        public async  Task<CuentaDto> RegistrarCuenta(CuentaDto cuenta)
        {

            var clienteEncontrado = _personaRepo.GetById(cuenta.ClienteId);
            if (clienteEncontrado != null)
            {
                var nuevaCuenta = new Cuenta
                {
                    NumeroCuenta = cuenta.NumeroCuenta,
                    TipoCuenta = cuenta.TipoCuenta,

                    SaldoInicial = cuenta.SaldoInicial,
                    Estado = cuenta.Estado,
                    Cliente = clienteEncontrado,

                };

                _db.Cuentas.Add(nuevaCuenta);
                await _db.SaveChangesAsync();
            }

            return cuenta;
        }

        Cuenta ICuentaRepository.ObtenerPorNumeroCuenta(string numeroCuenta)
        {
            try
            {
                return _db.Cuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
            }
            catch (Exception ex)
            {

                throw new ArgumentException("No se encontró una cuenta con el número de cuenta proporcionado.");
            }

        }

        public Cuenta GetById(int id)
        {
            return _db.Cuentas.SingleOrDefault(x => x.CuentaId == id);
        }

        public void Update(Cuenta entidad)
        {
            _db.Attach(entidad);
            _db.Entry(entidad).State = EntityState.Modified;
            _db.SaveChanges();
        }


    }
}
