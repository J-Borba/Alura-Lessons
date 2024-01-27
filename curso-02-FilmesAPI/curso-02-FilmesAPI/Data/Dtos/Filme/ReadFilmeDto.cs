using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Filme
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraConsulta { get; } = DateTime.Now;
    }
}
