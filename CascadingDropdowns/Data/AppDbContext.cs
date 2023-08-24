using CascadingDropdowns.Models;
using Microsoft.EntityFrameworkCore;

namespace CascadingDropdowns.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<State> State { get; set; }
        public DbSet <Country> Country { get; set; }
    }
}
