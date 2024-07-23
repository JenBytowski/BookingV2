using AutoMapper;
using BookingV2.Logic.Models;
using BookinV2.Data.Entities.RealEstateEntities;

namespace BookingV2.Logic.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<RealEstate, RealEstateDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Square, opt => opt.MapFrom(src => src.Square))
                .ForMember(dest => dest.RoomCount, opt => opt.MapFrom(src => src.RoomCount))
                .ReverseMap();

            CreateMap<Advertisement, AdvertisementDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.RealEstateId, opt => opt.MapFrom(src => src.RealEstateId))
                .ForMember(dest => dest.RealEstate, opt => opt.MapFrom(src => src.RealEstate))
                .ReverseMap();

            CreateMap<RealEstatePhoto, RealEstatePhotoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RealEstateId, opt => opt.MapFrom(src => src.RealEstateId))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ReverseMap();
        }
    }
}
