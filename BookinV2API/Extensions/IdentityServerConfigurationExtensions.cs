using BookinV2.Data;
using BookinV2.Data.Entities.IdentityEntities;
using BookinV2.Data.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookinV2API.Extensions
{
    public static class IdentityServerConfigurationExtensions
    {
        public static void AddIdentityServerConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<BookingIdentityDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookingIdentityDBContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IBookinV2DataContext, BookingV2DataContext>();

            var identityResources = configuration.GetSection("IdentityServer:IdentityResources").Get<List<IdentityResource>>();
            var apiScopes = configuration.GetSection("IdentityServer:ApiScopes").Get<List<ApiScope>>();
            var clients = configuration.GetSection("IdentityServer:Clients").Get<List<Client>>();

            services.AddIdentityServer(x =>
            {
                x.Logging.TokenRequestSensitiveValuesFilter =
                    new HashSet<string>
                    {
                        OidcConstants.TokenRequest.ClientSecret,
                        OidcConstants.TokenRequest.Password,
                        OidcConstants.TokenRequest.ClientAssertion,
                        OidcConstants.TokenRequest.RefreshToken,
                        OidcConstants.TokenRequest.DeviceCode,
                    };
            })
            .AddDeveloperSigningCredential()
            .AddInMemoryIdentityResources(identityResources)
            .AddInMemoryApiScopes(apiScopes)
            .AddInMemoryClients(clients)
            .AddAspNetIdentity<ApplicationUser>();

            services.AddAuthentication()
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:7224";
                    options.RequireHttpsMetadata = false;
                    options.IncludeErrorDetails = true;
                    options.IncludeErrorDetails = true;
                    options.TokenValidationParameters.ValidateAudience = false;
                });
        }
    }
}
