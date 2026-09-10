using ApartmentDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentInfrastructure.Data;

public class ApartmentDbContext : DbContext
{
    public ApartmentDbContext(
        DbContextOptions<ApartmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
        public DbSet<Flat> Flats { get; set; }

    public DbSet<Building> Buildings { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

    public DbSet<Notice> Notices { get; set; }
        public DbSet<Parking> Parkings { get; set; }

    public DbSet<Document> Documents { get; set; }
        public DbSet<Staff> Staffs { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // USER
        modelBuilder.Entity<User>(entity =>
            // Flat configuration
            modelBuilder.Entity<Flat>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                entity.Property(x => x.FlatNumber)
                .IsRequired()
                .HasMaxLength(100);
                      .HasMaxLength(20);

            entity.Property(x => x.Email)
                entity.Property(x => x.FlatType)
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
                entity.Property(x => x.Amount)
                      .HasPrecision(18, 2);

            entity.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(x => x.TotalFloors)
                .IsRequired();

            entity.Property(x => x.TotalFlats)
                entity.Property(x => x.Status)
                .IsRequired();

            entity.Property(x => x.IsActive)
                .IsRequired();
                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.Cascade);
        });

        // NOTICE
        modelBuilder.Entity<Notice>(entity =>
            // Parking configuration
            modelBuilder.Entity<Parking>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                entity.Property(x => x.SlotNumber)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .IsRequired();

            entity.Property(x => x.PostedDate)
                .IsRequired();
                      .HasMaxLength(20);

            entity.Property(x => x.PostedBy)
                .IsRequired();
                entity.Property(x => x.VehicleNumber)
                      .HasMaxLength(20);

            entity.Property(x => x.Status)
                .IsRequired();

                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.SetNull);
        });

        // DOCUMENT
        modelBuilder.Entity<Document>(entity =>
            // Staff configuration
            modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title)
                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .HasMaxLength(500);
                      .HasMaxLength(100);

            entity.Property(x => x.FileName)
                entity.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(255);
                      .HasMaxLength(15);

            entity.Property(x => x.FilePath)
                entity.Property(x => x.JobRole)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(x => x.UploadedDate)
                .IsRequired();

            entity.Property(x => x.UploadedBy)
                .IsRequired();
                      .HasMaxLength(50);

            entity.Property(x => x.Status)
                .IsRequired();
        });
    }
}
}
