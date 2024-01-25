using curso_02_FilmesAPI.Data;
using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            var result = _context.Filmes.FirstOrDefault(f => f.Id == id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }
    }
}
