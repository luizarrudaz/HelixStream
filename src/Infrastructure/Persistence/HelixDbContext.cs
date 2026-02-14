using HelixStream.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class HelixDbContext : DbContext
{
    public HelixDbContext(DbContextOptions<HelixDbContext> options) : base(options) { }

    public DbSet<GenomeSequence> Sequences => Set<GenomeSequence>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenomeSequence>(builder =>
        {
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.FilePath).IsRequired();
            builder.Property(s => s.Label).HasMaxLength(200);
            builder.Property(s => s.UploadedAt).IsRequired();
            
            builder.Property(s => s.Status)
                   .HasConversion<int>()
                   .IsRequired();
        });
    }
}