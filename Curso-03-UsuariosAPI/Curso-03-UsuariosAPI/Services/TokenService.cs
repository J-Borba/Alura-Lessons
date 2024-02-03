using Curso_03_UsuariosAPI.Models;
using Curso_03_UsuariosAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Curso_03_UsuariosAPI.Services;

public class TokenService : ITokenService
{
    public string GetToken(User user)
    {
        var claims = new Claim[]
        {
            new("id", user.Id),
            new("username", user.UserName),
            new(ClaimTypes.DateOfBirth, user.BirthDate.ToShortDateString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e90FJWRE90CK9QEVM902F=K329FVNR2I-249FE-"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}