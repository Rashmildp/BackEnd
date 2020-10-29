using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SugestorBackend.Models
{
    public partial class SuggestorContext : DbContext
    {
        

        public SuggestorContext(DbContextOptions<SuggestorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventPlanner> EventPlanner { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<TourGuide> TourGuide { get; set; }
        public virtual DbSet<TransportProvider> TransportProvider { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventPlanner>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__EventPla__2DC7BD091D70B117");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("eventName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notifications)
                    .HasColumnName("notifications")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDetails)
                    .HasColumnName("otherDetails")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Venue)
                    .IsRequired()
                    .HasColumnName("venue")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventPlanner)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("EP_fk");
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PK__Hotels__17ADC472F2E040B6");

                entity.Property(e => e.HotelId)
                    .HasColumnName("hotelId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Features)
                    .HasColumnName("features")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasColumnName("hotelName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notifications)
                    .HasColumnName("notifications")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDetails)
                    .HasColumnName("otherDetails")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Venue)
                    .HasColumnName("venue")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Hotel_fk");
            });

            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.HasKey(e => e.GuideId)
                    .HasName("PK__TourGuid__E77EE05EB72B2A31");

                entity.Property(e => e.GuideId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Languages)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notifications)
                    .HasColumnName("notifications")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OtherDetails)
                    .HasColumnName("otherDetails")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PhonenNmber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TourGuide)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("TG_fk");
            });

            modelBuilder.Entity<TransportProvider>(entity =>
            {
                entity.HasKey(e => e.Tpid)
                    .HasName("PK__Transpor__A0726B6ACE61FF4E");

                entity.Property(e => e.Tpid)
                    .HasColumnName("TPId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CostPerDistance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notifications)
                    .HasColumnName("notifications")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TypesOfVehicles)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TransportProvider)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("TP_fk");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__CB9A1CFF31A92363");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNo)
                    .IsRequired()
                    .HasColumnName("House_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lane)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
