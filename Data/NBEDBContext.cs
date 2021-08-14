using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HotelNorthernBreeze.Models;

#nullable disable

namespace HotelNorthernBreeze.Data
{
    public partial class NBEDBContext : DbContext
    {
        public NBEDBContext()
        {
        }

        public NBEDBContext(DbContextOptions<NBEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.Category, e.Size, e.UserNic, e.FromDate, e.ToDate })
                    .HasName("Booking_PK");

                entity.ToTable("Booking");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserNic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserNIC");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserNic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_User_FK");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => new { d.Category, d.Size })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Booking_Room_FK");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => new { e.Category, e.Size })
                    .HasName("Room_PK");

                entity.ToTable("Room");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Nic)
                    .HasName("User_PK");

                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "User_Email_Unique")
                    .IsUnique();

                entity.Property(e => e.Nic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NIC");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
