using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Models
{
    public class Cinema
    {
        [Key, Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Um cinema precisa conter pelo menos um endereço.")]
        public List<Endereco> Enderecos { get; set; }
    }
}
