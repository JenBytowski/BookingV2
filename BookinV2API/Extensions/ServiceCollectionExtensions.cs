using BookingV2.Logic.Contract;
using BookingV2.Logic.Services;
using BookinV2API.Mappings;

namespace BookinV2API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRealEstateService, RealEstateService>();
        }
    }
}
