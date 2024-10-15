using Microsoft.EntityFrameworkCore;
using ProjetoBusca.Models;

namespace ProjetoBusca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Remova o uso de UseModel aqui
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui, se houver outras configurações de modelo, deixe-as
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}