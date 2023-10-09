using GameAPI.DAL.Interfaces.Base;
using GameAPI.DAL.Interfaces.Services;
using GameAPI.DAL.Models;
using GameAPI.DAL.Services;
using GameAPI.DAL.Services.Base;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IBaseRepository<Game>, BaseRepository<Game>>();
builder.Services.AddScoped<IBaseRepository<Genre>, BaseRepository<Genre>>();

builder.Services.AddScoped<ICreator<Game>, Creator<Game>>();
builder.Services.AddScoped<IReador<Game>, Reador<Game>>();
builder.Services.AddScoped<IDeletor<Game>, Deletor<Game>>();

builder.Services.AddScoped<ICreator<Genre>, Creator<Genre>>();
builder.Services.AddScoped<IReador<Genre>, Reador<Genre>>();
builder.Services.AddScoped<IDeletor<Genre>, Deletor<Genre>>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
