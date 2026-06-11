using BioSampleManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BioSampleManager.Data;

public class AppDbContext : DbContext
{
    public DbSet<BiologicalSample> Samples => Set<BiologicalSample>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=biological_samples.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<BiologicalSample>()
            .Property(s => s.Name)
            .IsRequired();
        
        modelBuilder.Entity<BiologicalSample>()
            .Property(s => s.Type)
            .HasConversion<string>();
    }
}