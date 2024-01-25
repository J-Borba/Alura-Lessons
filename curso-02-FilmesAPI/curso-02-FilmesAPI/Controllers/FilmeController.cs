using AutoMapper;
using curso_02_FilmesAPI.Data;
using curso_02_FilmesAPI.Data.Dtos;
using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
                return NotFound();

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }
        
        [HttpPatch("{id}")]
        public IActionResult PatchFilme(int id, [FromBody] JsonPatchDocument<UpdateFilmeDto> filmeJsonDto)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
                return NotFound();

            var patchFilme = _mapper.Map<UpdateFilmeDto>(filme);

            filmeJsonDto.ApplyTo(patchFilme, ModelState);

            if (!TryValidateModel(patchFilme))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(patchFilme, filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
