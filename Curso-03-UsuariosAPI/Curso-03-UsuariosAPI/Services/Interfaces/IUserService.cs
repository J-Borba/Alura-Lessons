using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Curso_03_UsuariosAPI.Data.Dtos.Usuario;
using Curso_03_UsuariosAPI.Models;

namespace Curso_03_UsuariosAPI.Services.Interfaces;

public interface IUserService
{
    public Task<ValidationResult> CreateUserAsync(CreateUserDto dto);
    public Task<(ValidationResult, string)> LoginUserAsync(LoginUserDto dto);
}
