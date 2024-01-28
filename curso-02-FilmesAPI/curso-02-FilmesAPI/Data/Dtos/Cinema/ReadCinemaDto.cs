using curso_02_FilmesAPI.Data.Dtos.Endereco;

namespace curso_02_FilmesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
    }
}
