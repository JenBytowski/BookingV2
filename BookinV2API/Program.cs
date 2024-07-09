using BookinV2.Data;
using BookinV2.Data.Entities;
using BookinV2.Data.Interfaces;
using BookinV2API;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookingV2DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookingV2DBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IBookinV2DataContext, BookingV2DataContext>();

var identityResources = builder.Configuration.GetSection("IdentityServer:IdentityResources").Get<List<IdentityResource>>();
var apiScopes = builder.Configuration.GetSection("IdentityServer:ApiScopes").Get<List<ApiScope>>();
var clients = builder.Configuration.GetSection("IdentityServer:Clients").Get<List<Client>>();

builder.Services.AddIdentityServer(x =>
{
    x.Logging.TokenRequestSensitiveValuesFilter =
            new HashSet<string>
            {
                OidcConstants.TokenRequest.ClientSecret,
                OidcConstants.TokenRequest.Password,
                OidcConstants.TokenRequest.ClientAssertion,
                OidcConstants.TokenRequest.RefreshToken,
                OidcConstants.TokenRequest.DeviceCode,
               // dcConstants.TokenRequest.
            };
})
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(identityResources)
    .AddInMemoryApiScopes(apiScopes)
    .AddInMemoryClients(clients)
    .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddAuthentication()
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7224";
        options.RequireHttpsMetadata = false;
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters.ValidateAudience = false;
    });

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = @"BookingV2Client/dist";
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.UseRouting();

app.UseIdentityServer();

// app.UseAuthentication();
app.UseAuthorization();

app.Use((y, x) =>
{
    return x.Invoke();
});

app.UseEndpoints(route =>
{
    route.MapControllers();
});

app.UseSpa(configuration =>
{
    configuration.Options.SourcePath = "BookingV2Client";
    configuration.UseProxyToSpaDevelopmentServer("http://localhost:4200");
});

app.Run();
