csharp
using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelBookingSystem.Infrastructure.Persistence
{
    public class HotelBookingSystemDbContext : DbContext
    {
        public HotelBookingSystemDbContext(DbContextOptions<HotelBookingSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        // Add DbSets for other entities as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("users");
                builder.HasKey(u => u.Id);
                builder.Property(u => u.Id).UseIdentityAlwaysColumn();
                builder.Property(u => u.Username).IsRequired().HasColumnType("text");
                builder.HasIndex(u => u.Username).IsUnique();
                builder.Property(u => u.Email).IsRequired().HasColumnType("text");
                builder.HasIndex(u => u.Email).IsUnique();
                builder.Property(u => u.PasswordHash).IsRequired().HasColumnType("text");
                builder.Property(u => u.Salt).IsRequired().HasColumnType("text");
                builder.Property(u => u.FirstName).IsRequired().HasColumnType("text");
                builder.Property(u => u.LastName).IsRequired().HasColumnType("text");
                builder.Property(u => u.Phone).HasColumnType("text");
                builder.Property(u => u.Role).IsRequired().HasColumnType("text").HasDefaultValue("guest");
                builder.HasCheckConstraint("chk_user_role", "role IN ('guest', 'staff', 'admin')");
                builder.Property(u => u.IsActive).HasDefaultValue(true);
                builder.Property(u => u.LastLogin).HasColumnType("timestamp with time zone");
                builder.Property(u => u.PasswordUpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.Property(u => u.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.Property(u => u.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            });

            // Configure Hotel entity
            modelBuilder.Entity<Hotel>(builder =>
            {
                builder.ToTable("hotels");
                builder.HasKey(h => h.Id);
                builder.Property(h => h.Id).UseIdentityAlwaysColumn();
                builder.Property(h => h.Name).IsRequired().HasColumnType("text");
                builder.Property(h => h.Location).IsRequired().HasColumnType("text");
                builder.Property(h => h.Address).IsRequired().HasColumnType("jsonb");
                builder.Property(h => h.Description).HasColumnType("text");
                builder.Property(h => h.Rating).HasColumnType("decimal(2, 1)").HasAnnotation("Relational:ColumnType", "decimal(2, 1)");
                builder.HasCheckConstraint("chk_hotel_rating", "rating BETWEEN 0 AND 5");
                builder.Property(h => h.StarRating).HasColumnType("integer");
                builder.HasCheckConstraint("chk_hotel_star_rating", "star_rating BETWEEN 1 AND 5");
                builder.Property(h => h.CheckInTime).IsRequired().HasColumnType("time").HasDefaultValue(new TimeSpan(15, 0, 0));
                builder.Property(h => h.CheckOutTime).IsRequired().HasColumnType("time").HasDefaultValue(new TimeSpan(11, 0, 0));
                builder.Property(h => h.ContactEmail).IsRequired().HasColumnType("text");
                builder.Property(h => h.ContactPhone).IsRequired().HasColumnType("text");
                builder.Property(h => h.IsActive).HasDefaultValue(true);
                builder.Property(h => h.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.Property(h => h.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
            });

            // Configure RoomType entity
            modelBuilder.Entity<RoomType>(builder =>
            {
                builder.ToTable("room_types");
                builder.HasKey(rt => rt.Id);
                builder.Property(rt => rt.Id).UseIdentityAlwaysColumn();
                builder.Property(rt => rt.HotelId).IsRequired();
                builder.Property(rt => rt.Name).IsRequired().HasColumnType("text");
                builder.Property(rt => rt.Description).IsRequired().HasColumnType("text");
                builder.Property(rt => rt.BaseCapacity).IsRequired().HasColumnType("integer");
                builder.HasCheckConstraint("chk_room_type_base_capacity", "base_capacity > 0");
                builder.Property(rt => rt.MaxCapacity).IsRequired().HasColumnType("integer");
                builder.HasCheckConstraint("chk_room_type_max_capacity", "max_capacity >= base_capacity");
                builder.Property(rt => rt.BasePrice).IsRequired().HasColumnType("decimal(10, 2)").HasAnnotation("Relational:ColumnType", "decimal(10, 2)");
                builder.HasCheckConstraint("chk_room_type_base_price", "base_price > 0");
                builder.Property(rt => rt.SizeSqft).HasColumnType("integer");
                builder.Property(rt => rt.BedConfiguration).IsRequired().HasColumnType("text");
                builder.Property(rt => rt.Amenities).HasColumnType("text[]");
                builder.Property(rt => rt.IsActive).HasDefaultValue(true);
                builder.Property(rt => rt.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.Property(rt => rt.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.HasOne<Hotel>()
                       .WithMany()
                       .HasForeignKey(rt => rt.HotelId);
                builder.HasIndex(rt => new { rt.HotelId, rt.Name }).IsUnique().HasDatabaseName("uq_hotel_room_type");
            });

            // Configure Room entity
            modelBuilder.Entity<Room>(builder =>
            {
                builder.ToTable("rooms");
                builder.HasKey(r => r.Id);
                builder.Property(r => r.Id).UseIdentityAlwaysColumn();
                builder.Property(r => r.HotelId).IsRequired();
                builder.Property(r => r.RoomTypeId).IsRequired();
                builder.Property(r => r.RoomNumber).IsRequired().HasColumnType("text");
                builder.HasCheckConstraint("chk_room_number_format", "room_number ~ '^[A-Za-z]?\\d+[A-Za-z]?$'");
                builder.Property(r => r.FloorNumber).IsRequired().HasColumnType("integer");
                builder.HasCheckConstraint("chk_room_floor_number", "floor_number >= 0");
                builder.Property(r => r.ViewType).HasColumnType("text");
                builder.HasCheckConstraint("chk_room_view_type", "view_type IN ('city', 'garden', 'pool', 'ocean', 'mountain')");
                builder.Property(r => r.IsSmoking).HasDefaultValue(false);
                builder.Property(r => r.IsAccessible).HasDefaultValue(false);
                builder.Property(r => r.IsActive).HasDefaultValue(true);
                builder.Property(r => r.CreatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.Property(r => r.UpdatedAt).HasColumnType("timestamp with time zone").HasDefaultValueSql("now()");
                builder.HasOne<Hotel>()
                       .WithMany()
                       .HasForeignKey(r => r.HotelId);
                builder.HasOne<RoomType>()
                       .WithMany()
                       .HasForeignKey(r => r.RoomTypeId);
                builder.HasIndex(r => new { r.HotelId, r.RoomNumber }).IsUnique().HasDatabaseName("uq_hotel_room_number");
            });

            // Configure other entities similarly
            // modelBuilder.Entity<RatePlan>(...)
            // modelBuilder.Entity<CancellationPolicy>(...)
            // modelBuilder.Entity<RoomPricing>(...)
            // modelBuilder.Entity<Reservation>(...)
            // modelBuilder.Entity<ReservationRoom>(...)
            // modelBuilder.Entity<Guest>(...)
            // modelBuilder.Entity<Payment>(...)
            // modelBuilder.Entity<Refund>(...)
            // modelBuilder.Entity<Facility>(...)
            // modelBuilder.Entity<Service>(...)
            // modelBuilder.Entity<RoomService>(...)
            // modelBuilder.Entity<Image>(...)
            // modelBuilder.Entity<Promotion>(...)
            // modelBuilder.Entity<Review>(...)
            // modelBuilder.Entity<RoomStatus>(...)
            // modelBuilder.Entity<Housekeeping>(...)
            // modelBuilder.Entity<AuditLog>(...)

            // Note: Table partitioning is a database-level feature and is not configured in Entity Framework Core.
            // Indexes are typically created via migrations after the initial model is defined.
        }
    }
}