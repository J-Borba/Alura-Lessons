using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Curso_03_UsuariosAPI.Models;

namespace Curso_03_UsuariosAPI.Services.Interfaces;

public interface IUserService
{
    public Task<ValidationResult> CreateUserAsync(CreateUserDto dto);
}
