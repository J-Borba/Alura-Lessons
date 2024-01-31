using AutoMapper;
using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Curso_03_UsuariosAPI.Models;
using Curso_03_UsuariosAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Curso_03_UsuariosAPI.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<ValidationResult> CreateUserAsync(CreateUserDto dto)
    {
        var validation = new ValidationResult();

        var user = _mapper.Map<User>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            validation.AddErrors(result.Errors.Select(x => x.Description));
        }

        return validation;
    }
}
