using AutoMapper;
using Curso_03_UsuariosAPI.Data.D0tos.Usuario;
using Curso_03_UsuariosAPI.Data.Dtos.Usuario;
using Curso_03_UsuariosAPI.Models;

namespace Curso_03_UsuariosAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, ReadUserDto>();
        CreateMap<CreateUserDto, User>();
    }
}
