using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyDataAccess.Data
{
    public static class DbContextFactory
    {
        private static ClubDBContext ClubDBContext = null;

        static DbContextFactory()
        {
            

            
        }

        public static ClubDBContext ClubDBContextInstance
        {
            get 
            {
                var optionsBuilder = new DbContextOptionsBuilder<ClubDBContext>();
                optionsBuilder.UseSqlServer("Data Source=SURFACE-KW4;Initial Catalog=ClubDB;Integrated Security=True;");
                ClubDBContext = new ClubDBContext(optionsBuilder.Options);

                return ClubDBContext; 
            }
        }
    }
}
