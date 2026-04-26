using Microsoft.EntityFrameworkCore;
using CorridaAPI.Models;

namespace CorridaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Motorista> Motoristas { get; set; }
    public DbSet<Passageiro> Passageiros { get; set; }
    public DbSet<Corrida> Corridas { get; set; }
}