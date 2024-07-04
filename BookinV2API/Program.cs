using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.MapControllers();

app.UseSpa(configuration =>
{
    configuration.Options.SourcePath = "BookingV2Client";
    configuration.UseProxyToSpaDevelopmentServer("http://localhost:4200");
});

app.Run();
