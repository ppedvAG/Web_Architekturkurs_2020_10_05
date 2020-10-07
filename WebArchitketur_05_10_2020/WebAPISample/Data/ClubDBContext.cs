using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public partial class ClubDBContext : DbContext
    {
       


        public ClubDBContext(DbContextOptions<ClubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clubs> Clubs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=SURFACE-KW4;Initial Catalog=ClubDB;Integrated Security=True;");
        //    }
        //}

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
