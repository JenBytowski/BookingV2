using BookingV2.Logic.Contract;
using BookingV2.Logic.Services;
using BookinV2API.Mappings;

namespace BookinV2API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }

        public static IServiceCollection AddRealEstateService(this IServiceCollection services)
        {
            services.AddScoped<IRealEstateService, RealEstateService>();
            return services;
        }
    }
}
