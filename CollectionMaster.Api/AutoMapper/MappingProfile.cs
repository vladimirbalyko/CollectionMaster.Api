using AutoMapper;

using CollectionMaster.Api.Models;
using CollectionMaster.DataAccess.EF.Models;
using CollectionMaster.DataAccess.EF.Models.Enums;

namespace CollectionMaster.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<MusicAlbum, Album>()
                .ForMember(dest =>
                    dest.AlbumId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest =>
                    dest.Singer,
                    opt => opt.MapFrom(src => src.Singer))
                .ForMember(dest =>
                    dest.Year,
                    opt => opt.MapFrom(src => src.Year))
                .ForMember(dest =>
                    dest.Logo,
                    opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.Type,
                    opt => opt.MapFrom(src => (AlbumType)src.Type));
            CreateMap<Album, MusicAlbum>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.AlbumId))
                .ForMember(dest =>
                    dest.Title,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Singer,
                    opt => opt.MapFrom(src => src.Singer))
                .ForMember(dest =>
                    dest.Year,
                    opt => opt.MapFrom(src => src.Year))
                .ForMember(dest =>
                    dest.Logo,
                    opt => opt.MapFrom(src => src.Logo))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest =>
                    dest.Type,
                    opt => opt.MapFrom(src => (int)src.Type));
        }
    }
}
