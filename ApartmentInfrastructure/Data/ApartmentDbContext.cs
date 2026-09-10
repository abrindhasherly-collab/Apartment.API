using ApartmentDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Data;

public class ApartmentDbContext : DbContext
{
    public ApartmentDbContext(
        DbContextOptions<ApartmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Notice> Notices { get; set; }

    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasIndex(x => x.Email)
                .IsUnique();

            entity.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            entity.Property(x => x.Role)
                .IsRequired();

            entity.Property(x => x.Status)
                .IsRequired();
        });

        // BUILDING
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(x => x.TotalFloors)
                .IsRequired();

            entity.Property(x => x.TotalFlats)
                .IsRequired();

            entity.Property(x => x.IsActive)
                .IsRequired();
        });

        // NOTICE
        modelBuilder.Entity<Notice>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .IsRequired();

            entity.Property(x => x.PostedDate)
                .IsRequired();

            entity.Property(x => x.PostedBy)
                .IsRequired();

            entity.Property(x => x.Status)
                .IsRequired();
        });

        // DOCUMENT
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(x => x.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(x => x.UploadedDate)
                .IsRequired();

            entity.Property(x => x.UploadedBy)
                .IsRequired();

            entity.Property(x => x.Status)
                .IsRequired();
        });
    }
}