using AutoMapper;
using curso_02_FilmesAPI.Data.Dtos.Cinema;
using curso_02_FilmesAPI.Models;

namespace curso_02_FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(dto => dto.Endereco,
                    config => config.MapFrom(c => c.Endereco));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
