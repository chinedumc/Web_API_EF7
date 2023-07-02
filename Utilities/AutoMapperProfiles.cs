using AutoMapper;
using webAPI_EF.DTOs;
using webAPI_EF.Entities;

namespace webAPI_EF.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap<CommentCreationDTO, Comment>();

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(ent => ent.Genres, 
                dto => dto.MapFrom(field => field.Genres.Select(id => new Genre() { Id = id })));

            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
