using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryImpl.EFContext
{
    public static class DbContextFactory
    {
        private static ClubDBContext ClubDBContext = null;

        static DbContextFactory()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClubDBContext>();
            optionsBuilder.UseSqlServer("Data Source=SURFACE-KW4;Initial Catalog=ClubDB;Integrated Security=True;");

            ClubDBContext = new ClubDBContext(optionsBuilder.Options);
        }

        public static ClubDBContext ClubDBContextInstance
        {
            get { return ClubDBContext; }
        }
    }
}
