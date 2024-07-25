using AutoMapper;
using BookinV2.Data.Entities.RealEstateEntities;
using BookinV2API.Models.DTOs;

namespace BookinV2API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RealEstateDto, RealEstateDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Square, opt => opt.MapFrom(src => src.Square))
                .ForMember(dest => dest.RoomCount, opt => opt.MapFrom(src => src.RoomCount))
                .ReverseMap();
        }
    }
}
