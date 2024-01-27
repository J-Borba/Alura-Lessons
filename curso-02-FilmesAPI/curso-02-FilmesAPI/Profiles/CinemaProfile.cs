using AutoMapper;
using curso_02_FilmesAPI.Data.Dtos.Cinema;
using curso_02_FilmesAPI.Models;

namespace curso_02_FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
