using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Ropas> Ropa { get; set; }
        public DbSet<EntradaRopas> EntradaRopa { get; set; }
        public DbSet<Facturas> Factura { get; set; }

        public DbSet<FacturaDetalle> Detalles { get; set; }
        public Contexto() : base("ConStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
