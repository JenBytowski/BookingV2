using BookingV2.Logic.Contract;
using BookingV2.Logic.Services;
using BookinV2.Data;
using Microsoft.EntityFrameworkCore;

namespace BookinV2API.Extensions
{
    public static class DBContextConfigurationExtentions
    {
        public static void AddDBContextServerConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<BookingV2DBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
