using ProjetoBusca.Models;
using ProjetoBusca.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBusca.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly CursoAutomationService _cursoAutomationService;

        public CursoService(ICursoRepository cursoRepository, CursoAutomationService cursoAutomationService)
        {
            _cursoRepository = cursoRepository;
            _cursoAutomationService = cursoAutomationService;
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

        // Nova função para buscar cursos na Alura e salvar no banco
        public async Task<List<Curso>> BuscarCursosNaAluraAsync(string termoBusca)
        {
            var cursos = await _cursoAutomationService.BuscarCursosAsync(termoBusca);

            // Salvar os cursos no banco de dados
            foreach (var curso in cursos)
            {
                await _cursoRepository.AddCursoAsync(curso);
            }

            return cursos;
        }
    }
}