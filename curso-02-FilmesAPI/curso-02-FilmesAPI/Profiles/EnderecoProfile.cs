using AutoMapper;
using curso_02_FilmesAPI.Data.Dtos.Endereco;
using curso_02_FilmesAPI.Models;

namespace curso_02_FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }
    }
}
