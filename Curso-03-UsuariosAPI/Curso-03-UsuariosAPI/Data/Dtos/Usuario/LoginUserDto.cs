using System.ComponentModel.DataAnnotations;

namespace Curso_03_UsuariosAPI.Data.Dtos.Usuario
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
