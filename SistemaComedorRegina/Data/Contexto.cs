using Microsoft.EntityFrameworkCore;
using SistemaComedorRegina.Domain.Models;

namespace SistemaComedorRegina.Data
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<Gastos> Gastos { get; set; }
        public DbSet<TipoGastos> TipoGastos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TipoGastos>().HasData(
                new TipoGastos { TipoGastoId = 1, Descripcion = "Diarios" },
                new TipoGastos { TipoGastoId = 2, Descripcion = "Administrativos" }
            );
        }

    }
}
