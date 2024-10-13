// Diretório: Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using RPA.Models;

namespace RPA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}