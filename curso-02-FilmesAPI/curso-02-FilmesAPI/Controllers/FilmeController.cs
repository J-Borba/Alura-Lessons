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

        /// <summary>
        /// Busca todos os filmes do banco de dados.
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Busca realizada com sucesso</response>
        /// <response code="404">Nenhum filme encontrado</response>
        [HttpGet]
        public IEnumerable<ReadFilmeDto> GetFilmes()
        {
            var filmes = _context.Filmes;

            var filmesDto = _mapper.Map<IEnumerable<ReadFilmeDto>>(filmes).ToList();

            return filmesDto;
        }

        /// <summary>
        /// Busca o filme do banco de dados pelo id.
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Busca realizada com sucesso</response>
        /// <response code="404">Nenhum filme encontrado</response>
        [HttpGet("{id}")]
        public IActionResult GetFilmeById(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound();

            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

            return Ok(filmeDto);
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados.
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Inserção realizada com sucesso</response>
        [HttpPost, ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Atualiza um filme do banco de dados.
        /// </summary>
        /// <param name="id">Id do filme para atualizar.</param>
        /// <param name="filmeDto">Objeto com os campos necessários para atualização de um filme.</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Atualização realizada com sucesso.</response>
        /// <response code="404">Nenhum filme encontrado.</response>
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

        /// <summary>
        /// Atualiza dados de um filme do banco de dados.
        /// </summary>
        /// <param name="id">Id do filme para atualizar.</param>
        /// <param name="filmeJsonDto">Objeto com os campos que deseja alterar de um filme.</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Atualização realizada com sucesso</response>
        /// <response code="404">Nenhum filme encontrado.</response>
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

        /// <summary>
        /// Deleta um filme do banco de dados.
        /// </summary>
        /// <param name="id">Id do filme para atualizar.</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Remoção realizada com sucesso</response>
        /// <response code="404">Nenhum filme encontrado.</response>
        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
