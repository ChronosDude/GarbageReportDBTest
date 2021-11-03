using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GarbageDBTest.Domain.Entities;

#nullable disable

namespace GarbageDBTest.Infraestructure.Data
{
    public partial class GarbageDBContext : DbContext
    {
        public GarbageDBContext()
        {
        }

        public GarbageDBContext(DbContextOptions<GarbageDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=GarbageDB.mssql.somee.com;packet size=4096;user id=JimmiAWS2;pwd=JimmiAWS2;data source=GarbageDB.mssql.somee.com;persist security info=False;initial catalog=GarbageDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Features)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("features");

                entity.Property(e => e.Geoubication)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("geoubication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.RequiredPersons).HasColumnName("requiredPersons");

                entity.Property(e => e.Sponsor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sponsor");

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("time");

                entity.Property(e => e.Ubication)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubication");
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("POIs");

                entity.Property(e => e.Colony)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("colony");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Geoubication)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("geoubication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reason");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
