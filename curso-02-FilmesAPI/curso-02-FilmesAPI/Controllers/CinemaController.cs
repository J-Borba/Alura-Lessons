using AutoMapper;
using curso_02_FilmesAPI.Data;
using curso_02_FilmesAPI.Data.Dtos.Cinema;
using curso_02_FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace curso_02_FilmesAPI.Controllers
{
    [ApiController, Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetAllCinemas()
        {
            var cinemas = _context.Cinemas.ToList();

            var dtos = _mapper.Map<List<ReadCinemaDto>>(cinemas);

            return dtos;
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] CreateCinemaDto dto)
        {
            var cinema = _mapper.Map<Cinema>(dto);
            cinema.Id = _context.Cinemas.Any() ? _context.Cinemas.Max(x => x.Id) : 0;
            cinema.Id++;

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCinemaById), new { Id = cinema.Id }, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto dto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema == null)
                return NotFound();

            _mapper.Map(dto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchCinema(int id, [FromBody] JsonPatchDocument<UpdateCinemaDto> dto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema == null)
                return NotFound();

            var patchCinema = _mapper.Map<UpdateCinemaDto>(cinema);

            dto.ApplyTo(patchCinema, ModelState);

            if (!TryValidateModel(patchCinema))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(patchCinema, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

            if (cinema == null)
                return NotFound();

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
