﻿using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Curso_03_UsuariosAPI.Data.Dtos.Usuario;
using Curso_03_UsuariosAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso_03_UsuariosAPI.Controllers;

[ApiController, Route("[controller]")]
public class UserController : ControllerBase
{
    #region Dependency Injections
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    #endregion

    //[HttpGet]
    //public IActionResult GetAllUsers()
    //{
    //    throw new NotImplementedException();
    //}

    //[HttpGet("{id}")]
    //public IActionResult GetUserById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    [HttpPost("Signin")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);

        return result.IsValid ? Ok("User created successfully.") : BadRequest(result.ErrorMessages);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        (var validation, string token) = await _userService.LoginUserAsync(dto);

        return validation.IsValid ? Ok($"User authenticated.\nToken: {token}") : BadRequest(validation.ErrorMessages);
    }
}