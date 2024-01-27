using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Cinema
{
public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
