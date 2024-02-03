using Curso_03_UsuariosAPI.Models;

namespace Curso_03_UsuariosAPI.Services.Interfaces;

public interface ITokenService
{
    public string GetToken(User user);
}
