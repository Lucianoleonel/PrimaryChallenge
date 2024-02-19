using Microsoft.EntityFrameworkCore;
using Primary.Domain;
using Primary.Domain.Entities;

namespace Primary.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        // DBSets para conectar con las tablas de la DB
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<TipoCambio> TipoCambio { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
    }

}
