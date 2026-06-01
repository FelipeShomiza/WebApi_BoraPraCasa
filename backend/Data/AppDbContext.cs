using Microsoft.EntityFrameworkCore;
using CorridaAPI.Models;

namespace CorridaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Corrida> Corridas { get; set; }
    }
}