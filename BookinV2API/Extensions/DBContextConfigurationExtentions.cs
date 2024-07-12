using BookinV2.Data;
using BookinV2.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookinV2API.Extensions
{
    public static class DBContextConfigurationExtentions
    {
        public static void AddDBContextConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<BookingV2DBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBookinV2DataContext, BookingV2DataContext>();
        }
    }
}
