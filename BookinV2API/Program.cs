using BookinV2API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDBContextServerConfiguration(builder.Configuration);

builder.Services.AddIdentityServerConfiguration(builder.Configuration);

builder.Services.AddCors(x =>
{
    x.AddPolicy("Frontend", y =>
    {
        y.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
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

app.UseCors("Frontend");

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
