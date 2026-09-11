using ApartmentDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentInfrastructure.Data
{
    public class ApartmentDbcontext : DbContext
    {
        public ApartmentDbcontext(DbContextOptions<ApartmentDbcontext> options)
            : base(options)
        {
        }

        public DbSet<ResidentEntity> Residents { get; set; }

        public DbSet<PaymentEntity> Payments { get; set; }

        public DbSet<ComplaintEntity> Complaints { get; set; }

        public DbSet<EmergencyEntity> Emergencies { get; set; }

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
                    .IsRequired();

                entity.Property(x => x.PhoneNumber)
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.Description)
                    .IsRequired();
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.FileName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(x => x.FilePath)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            // Flat configuration
            modelBuilder.Entity<Flat>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FlatNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.FlatType)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.Status)
                      .IsRequired();
            });

            // Maintenance configuration
            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Amount)
                      .HasPrecision(18, 2);

                entity.Property(x => x.Status)
                      .IsRequired();

                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Parking configuration
            modelBuilder.Entity<Parking>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.SlotNumber)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(x => x.VehicleNumber)
                      .HasMaxLength(20);

                entity.Property(x => x.Status)
                      .IsRequired();

                entity.HasOne<Flat>()
                      .WithMany()
                      .HasForeignKey(x => x.FlatId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            // Staff configuration
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(x => x.Phone)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(x => x.JobRole)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(x => x.Status)
                      .IsRequired();
            });

            modelBuilder.Entity<PaymentEntity>()
            .HasOne<Maintenance>()
            .WithMany()
            .HasForeignKey(p => p.MaintenanceId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}