using Microsoft.AspNetCore.Authorization;

namespace Curso_03_UsuariosAPI.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public IdadeMinima(int idade)
    {
        Idade = idade;
    }
    public int Idade { get; set; }
}
