using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
