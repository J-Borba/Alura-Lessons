using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso_03_UsuariosAPI.Controllers;

[ApiController, Route("[controller]")]
public class AcessoController : ControllerBase
{
    [HttpGet, Authorize("IdadeMinima")]
    public IActionResult Get()
    {
        return Ok("Acesso Permitido.");
    }
}
