using Microsoft.AspNetCore.Identity;

namespace Curso_03_UsuariosAPI.Models;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }

    public User() : base() { }
}
