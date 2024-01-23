using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int Id = 0;

        [Route("/[controller]/buscar"), HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            return filmes;
        }

        [Route("/[controller]/buscar/{id}"), HttpGet]
        public IActionResult GetFilmeById(int id)
        {
            var result = filmes.FirstOrDefault(f => f.Id == id);

            return result == null ? NotFound() : Ok(result);
        }

        [Route("/[controller]/adicionar"), HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = Id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }
    }
}
