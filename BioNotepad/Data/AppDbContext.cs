using Microsoft.EntityFrameworkCore;
using BioNotepad.Models;
using System;
using System.IO;

namespace BioNotepad.Data;

public class AppDbContext : DbContext
{
    public DbSet<AnalysisSession> Sessions { get; set; }
    public DbSet<SessionEntry> Entries { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, "BioNotepad", "bionotepad.db");
        
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalysisSession>()
            .HasMany(s => s.Entries)
            .WithOne(e => e.AnalysisSession)
            .HasForeignKey(e => e.AnalysisSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SessionEntry>()
            .HasMany(e => e.Attachments)
            .WithOne(a => a.SessionEntry)
            .HasForeignKey(a => a.SessionEntryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}