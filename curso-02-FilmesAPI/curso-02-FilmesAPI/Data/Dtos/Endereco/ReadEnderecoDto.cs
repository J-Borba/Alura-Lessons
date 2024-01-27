using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
