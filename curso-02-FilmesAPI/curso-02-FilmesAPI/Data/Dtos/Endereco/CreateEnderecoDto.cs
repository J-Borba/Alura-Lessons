using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
