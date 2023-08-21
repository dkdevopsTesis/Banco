using Microsoft.EntityFrameworkCore;

namespace Prueba.Model
{
    public class ApplicationDbContext: DbContext


    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=prueba; User Id=sa; Password=Aa123456!;TrustServerCertificate=True; Trusted_Connection=false    ; MultipleActiveResultSets=true;");

        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
    }
}
