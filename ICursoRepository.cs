// Diretório: Repositories/Interfaces/ICursoRepository.cs
using RPA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPA.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursosAsync();
        Task<Curso?> GetCursoByIdAsync(int id);
        Task AddCursoAsync(Curso curso);
    }
}