using AutoMapper;
using curso_02_FilmesAPI.Data.Dtos.Sessao;
using curso_02_FilmesAPI.Models;

namespace curso_02_FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<UpdateSessaoDto, Sessao>();
            CreateMap<Sessao, UpdateSessaoDto>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
