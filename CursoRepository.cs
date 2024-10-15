// Diretório: Repositories/CursoRepository.cs
using Microsoft.EntityFrameworkCore;
using ProjetoBusca.Data;
using ProjetoBusca.Models;
using ProjetoBusca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBusca.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> GetCursosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso?> GetCursoByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task AddCursoAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }
    }
}