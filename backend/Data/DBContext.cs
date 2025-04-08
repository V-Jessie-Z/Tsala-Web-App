using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; 
using Backend.Models;

namespace Backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        // Define DbSet for each model (table)
        public DbSet<User> Users { get; set; }





















        // Configure the PostgreSQL database provider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");  // Use your actual PostgreSQL connection string
            }
        }
    }
}
