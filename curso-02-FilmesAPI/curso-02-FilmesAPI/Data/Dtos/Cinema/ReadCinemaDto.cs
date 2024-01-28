using curso_02_FilmesAPI.Data.Dtos.Endereco;
using curso_02_FilmesAPI.Data.Dtos.Sessao;

namespace curso_02_FilmesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDto Endereco { get; set; }
        public List<ReadSessaoDto> Sessoes { get; set; }
    }
}
