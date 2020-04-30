using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Olympiad__project_code.Models
{
    public partial class OlympicGamesDBContext : DbContext
    {
        public OlympicGamesDBContext()
        {
        }

        public OlympicGamesDBContext(DbContextOptions<OlympicGamesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Coaches> Coaches { get; set; }
        public virtual DbSet<Competitors> Competitors { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database= OlympicGamesDB; Integrated Security=True;");
                //optionsBuilder.UseSqlServer("Server = .\\SQLEXPRESS; Database= TestDB; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coaches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Coaches__SportId__5FB337D6");
            });

            modelBuilder.Entity<Competitors>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Competit__3213E83EE8CA782C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK__Competito__ClubI__0F624AF8");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK__Competito__Coach__10566F31");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.SportId)
                    .HasConstraintName("FK__Competito__Sport__114A936A");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK__Competito__TownI__0E6E26BF");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Countrie__3213E83E4C90BE17")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Sports__3213E83E4B45F587")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Towns__3213E83E336D18CD")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Towns__CountryId__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
