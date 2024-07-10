using BookinV2.Data;
using BookinV2.Data.Entities.IdentityEntities;
using BookinV2.Data.Interfaces;
using BookinV2API.Extensions;
using IdentityModel;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookingV2DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityServerConfiguration(builder.Configuration);

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

app.UseAuthorization();

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
