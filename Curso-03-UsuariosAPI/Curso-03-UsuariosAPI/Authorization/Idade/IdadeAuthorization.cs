using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Curso_03_UsuariosAPI.Authorization.Idade;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var birthClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

        if (birthClaim is null)
            return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthClaim.Value);

        bool isAuthorized = birthDate.AddYears(requirement.Idade) <= DateTime.Today;
        if (isAuthorized)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
