using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Campo Nome Obrigatório.")]
        public string Nome { get; set; }
    }
}
