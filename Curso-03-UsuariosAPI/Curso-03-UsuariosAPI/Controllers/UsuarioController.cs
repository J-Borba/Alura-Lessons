using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Curso_03_UsuariosAPI.Controllers;

[ApiController, Route("[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        throw new NotImplementedException();
    }
}