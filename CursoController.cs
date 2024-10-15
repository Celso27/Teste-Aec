using Microsoft.AspNetCore.Mvc;
using ProjetoBusca.Models;
using ProjetoBusca.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoBusca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET /api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoService.GetCursosAsync();
            return Ok(cursos);
        }

        // GET /api/cursos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // POST /api/cursos
        [HttpPost]
        public async Task<ActionResult> AddCurso(Curso curso)
        {
            await _cursoService.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        // POST /api/cursos/buscar-na-alura
        [HttpPost("buscar-na-alura")]
        public async Task<ActionResult> BuscarCursosNaAlura([FromBody] string termoBusca)
        {
            var cursos = await _cursoService.BuscarCursosNaAluraAsync(termoBusca);
            return Ok(cursos);
        }
    }
}