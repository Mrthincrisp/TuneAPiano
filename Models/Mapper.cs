using AutoMapper;
namespace TuneAPiano.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Song(first position) is the source,   SongDTO(second position) is the Destination
            CreateMap<Song, SongDTO>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.SongGenres.Select(sg => sg.Genre)))
            .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
            .ReverseMap();
            /*
              ***BREAK DOWN OF HOW MAPPER DEATILS WORK***
             The first ForMember specifies the mapper to map Generes to SongDTO, dest.Genres = SongDTO.Genres
             opt.MapFrom is an option the mapper has. This could be other options such as, opt.Condition(which maps if a condition is met) or opt.Ignore(ignores a property from being mapped)
            (src => src.SongGenres.Select(sg => sg.Genre) can be read as ---Song.SongGenre.Select(songGenre.Genre)--- which selects the genre from the join table
            .ReverseMap() essentialy allows for the source, and destination to swap, and map from that.
             
             */
            CreateMap<Song, NewSongDTO>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
