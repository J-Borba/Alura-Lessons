using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public DateTime HoraConsulta { get; } = DateTime.Now;
    }
}
