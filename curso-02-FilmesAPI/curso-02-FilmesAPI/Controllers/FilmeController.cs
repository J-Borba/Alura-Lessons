using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        [HttpGet]
        [Route("/buscar")]
        public List<Filme> GetFilmes()
        {
            return filmes;
        }

        [HttpPost]
        [Route("/adicionar")]
        public void AdicionarFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
        }
    }
}
