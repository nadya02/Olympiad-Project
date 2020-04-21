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

        public virtual DbSet<Coaches> Coaches { get; set; }
        public virtual DbSet<Competitors> Competitors { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=OlympicGamesDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coaches>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Competitors>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Competit__3213E83E3481C9B6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CoachId).HasColumnName("Coach_id");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SportId).HasColumnName("Sport_id");

                entity.Property(e => e.TownId).HasColumnName("Town_id");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__Coach__32E0915F");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__Sport__31EC6D26");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Competito__Town___30F848ED");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Countrie__3213E83E1CF707FD")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sports>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__Sports__3213E83EFD775500")
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
                    .HasName("UQ__Towns__3213E83EC478D2CC")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Towns)
                    .HasForeignKey<Towns>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Towns__id__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
