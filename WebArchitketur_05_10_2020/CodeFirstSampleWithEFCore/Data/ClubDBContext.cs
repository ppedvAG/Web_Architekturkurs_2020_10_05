using CodeFirstSampleWithEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstSampleWithEFCore.Data
{
    public class ClubDBContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SURFACE-KW4;Initial Catalog=ClubDB;Integrated Security=True;");
        }
            
    }
}
