using Microsoft.EntityFrameworkCore;
using CorridaAPI.Data;
using CorridaAPI.Repositories;
using CorridaAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=corrida.db"));


builder.Services.AddScoped<ICorridaRepository, CorridaRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();