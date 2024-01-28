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

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

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
            sessao.Id = _context.Sessoes.Any() ? _context.Sessoes.Max(x => x.Id) : 0;
            sessao.Id++;

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessaoById), new { id = sessao.Id }, sessao);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDto dto)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

            if (sessao == null)
                return NotFound();

            _mapper.Map(dto, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSessao(int id, [FromBody] JsonPatchDocument<UpdateSessaoDto> dto)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

            if (sessao == null)
                return NotFound();

            var patchSessao = _mapper.Map<UpdateSessaoDto>(sessao);

            dto.ApplyTo(patchSessao, ModelState);

            if (!TryValidateModel(patchSessao))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(patchSessao, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

            if (sessao == null)
                return NotFound();

            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
