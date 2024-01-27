using AutoMapper;
using curso_02_FilmesAPI.Data.Dtos.Endereco;
using curso_02_FilmesAPI.Data;
using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController ,Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> GetAllEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();

            var dtos = _mapper.Map<List<ReadEnderecoDto>>(enderecos);

            return dtos;
        }

        [HttpGet("{id}")]
        public IActionResult GetEnderecoById(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto dto)
        {
            var endereco = _mapper.Map<Endereco>(dto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEnderecoById), new { id = endereco.Id }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto dto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null)
                return NotFound();

            _mapper.Map(dto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEndereco(int id, [FromBody] JsonPatchDocument<UpdateEnderecoDto> dto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null)
                return NotFound();

            var patchEndereco = _mapper.Map<UpdateEnderecoDto>(endereco);

            dto.ApplyTo(patchEndereco, ModelState);

            if (!TryValidateModel(patchEndereco))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(patchEndereco, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null)
                return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
