using AutoMapper;
using MyAnimeList.Application.Dtos;
using MyAnimeList.Domain;
using MyAnimeList.Domain.Identity;

namespace MyAnimeList.API.Helpers
{
    public class MyAnimeListProfile : Profile
    {

        public MyAnimeListProfile()
        {
            CreateMap<Anime, AnimeDto>().ReverseMap();
            CreateMap<AnimeEstudio, AnimeEstudioDto>().ReverseMap();
            CreateMap<AnimeGenero, AnimeGeneroDto>().ReverseMap();
            CreateMap<Demographic, DemographicDto>().ReverseMap();
            CreateMap<Estudio, EstudioDto>().ReverseMap();
            CreateMap<Fonte, FonteDto>().ReverseMap();
            CreateMap<Genero, GeneroDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
        
    }
}