using AutoMapper;
using curso_02_FilmesAPI.Data;
using curso_02_FilmesAPI.Data.Dtos.Sessao;
using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController, Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> GetAllSessoes()
        {
            var sessoes = _context.Sessoes.ToList();

            var dtos = _mapper.Map<List<ReadSessaoDto>>(sessoes);

            return dtos;
        }

        [HttpGet("{cinemaId}/{filmeId}")]
        public IActionResult GetSessaoById(int cinemaId, int filmeId)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.CinemaId == cinemaId && x.FilmeId == filmeId);

            if (sessao == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
        {
            var sessao = _mapper.Map<Sessao>(dto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessaoById), new { cinemaId = sessao.CinemaId, filmeId = sessao.FilmeId }, sessao);
        }

        [HttpDelete("{cinemaId}/{filmeId}")]
        public IActionResult DeletarSessao(int cinemaId, int filmeId)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.CinemaId == cinemaId && x.FilmeId == filmeId);

            if (sessao == null)
                return NotFound();

            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
