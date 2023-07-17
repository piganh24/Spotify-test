using AutoMapper;
using Core.Entities;
using Core.DTOs.Album;
using Core.DTOs.Genre;
using Core.DTOs.Playlist;
using Core.DTOs.Publisher;
using Core.DTOs.Track;

namespace Core.Helpers
{
    public class AppMapProfile : Profile
    {
        private readonly string _images = "/images/";
        private readonly string _tracks = "/tracks/";
        public AppMapProfile()
        {
            CreateMap<AlbumCreateDTO, Album>();
            CreateMap<AlbumUpdateDTO, Album>();
            CreateMap<Album, AlbumItemDTO>()
                  .ForMember(album => album.Image, opt => opt.MapFrom(album => _images + $"{album.Image}"));

            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();
            CreateMap<Genre, GenreItemDTO>()
              .ForMember(genre => genre.Image, opt => opt.MapFrom(genre => _images + $"{genre.Image}"));

            CreateMap<PlaylistCreateDTO, Playlist>();
            CreateMap<PlaylistUpdateDTO, Playlist>();
            CreateMap<Playlist, PlaylistItemDTO>()
               .ForMember(playlist => playlist.Image, opt => opt.MapFrom(playlist => _images + $"{playlist.Image}"));

            CreateMap<PublisherCreateDTO, Publisher>();
            CreateMap<PublisherUpdateDTO, Publisher>();
            CreateMap<Publisher, PublisherItemDTO>()
                .ForMember(publisher => publisher.Image, opt => opt.MapFrom(publisher => _images + $"{publisher.Image}"));

            CreateMap<TrackCreateDTO, Track>();
            CreateMap<TrackUpdateDTO, Track>();
            CreateMap<Track, TrackItemDTO>()
              .ForMember(track => track.Image, opt => opt.MapFrom(track => _images + $"{track.Image}"))
              .ForMember(track => track.Track, opt => opt.MapFrom(track => _tracks + $"{track.Path}"));
        }
    }
}