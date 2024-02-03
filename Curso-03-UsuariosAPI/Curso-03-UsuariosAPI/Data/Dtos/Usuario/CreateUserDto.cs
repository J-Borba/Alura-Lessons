using System.ComponentModel.DataAnnotations;

namespace Curso_03_UsuariosAPI.Data.D0tos.Usuario;

public class CreateUserDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required, Compare(nameof(Password))]
    public string PasswordConfirmation { get; set; } = string.Empty;
}