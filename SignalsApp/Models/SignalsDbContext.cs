using Microsoft.EntityFrameworkCore;

namespace SignalsApp.Models;

public class SignalsDbContext : DbContext
{
    public DbSet<Signal> Signals { get; set; }
    public DbSet<Message> Messages { get; set; }

    public SignalsDbContext(DbContextOptions<SignalsDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Signal>().ToTable("Signal");
        modelBuilder.Entity<Message>().ToTable("Message");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("SignalsDbConnectionString");
        optionsBuilder.UseSqlServer(connectionString);
    }

}