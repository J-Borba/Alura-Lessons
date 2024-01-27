using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Models
{
    public class Endereco
    {
        [Key, Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
