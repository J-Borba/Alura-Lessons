using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Models
{
    public class Sessao
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
