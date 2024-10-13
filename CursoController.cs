// Diretório: Controllers/CursoController.cs
using Microsoft.AspNetCore.Mvc;
using RPA.Models;
using RPA.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPA.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoService.GetCursosAsync();
            return Ok(cursos);
        }

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

        [HttpPost]
        public async Task<ActionResult> AddCurso(Curso curso)
        {
            await _cursoService.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }
    }
}