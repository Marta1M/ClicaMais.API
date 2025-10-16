
using ClicaMais.Application;
using ClicaMais.Application.Services;
using ClicaMais.Domain.Repositories;
using ClicaMais.Infrastructure.Repositories;
using ClicaMais.Infrastructure.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "clicaMais.db");

builder.Services.AddDbContext<AppDbContext>(op =>
    op.UseSqlite($"Data Source={dbPath}"));

//builder.Services.AddDbContext<AppDbContext>(op =>
//op.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ApplicationAssembyMarker).Assembly);
builder.Services.AddScoped<ISaqueRepository,SaqueRepository>();
builder.Services.AddScoped<IJogadorRepository, JogadorRepository>();
builder.Services.AddScoped<INivelRepository, NivelRepository>();
builder.Services.AddScoped<INivelService, NivelService>();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy
            .WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("PermitirFrontend");
app.MapControllers();

app.Run();
