using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RepositoryImpl.Entities;

namespace RepositoryImpl.EFContext
{
    public partial class ClubDBContext : DbContext
    {
        public ClubDBContext()
        {
        }

        public ClubDBContext(DbContextOptions<ClubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clubs> Clubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SURFACE-KW4;Initial Catalog=ClubDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.Property(e => e.ArenaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
