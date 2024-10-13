// Diretório: Services/CursoService.cs
using RPA.Models;
using RPA.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPA.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> GetCursosAsync()
        {
            return await _cursoRepository.GetCursosAsync();
        }

        public async Task<Curso?> GetCursoByIdAsync(int id)
        {
            return await _cursoRepository.GetCursoByIdAsync(id);
        }

        public async Task AddCursoAsync(Curso curso)
        {
            await _cursoRepository.AddCursoAsync(curso);
        }
    }
}