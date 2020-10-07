using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public static class DataSeed
    {

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (ClubDBContext ctx = new ClubDBContext(serviceProvider.GetRequiredService<DbContextOptions<ClubDBContext>>()))
            {
                if (!ctx.Clubs.Any())
                {
                    ctx.Clubs.Add(new Clubs { FoundingYear = new DateTime(1919, 02, 02), Name = "SC Freiburg", ArenaName = "An der schöne Wiese", ArenaCapacity = 20000, TransferBudget = 10000000 });
                    ctx.Clubs.Add(new Clubs { FoundingYear = new DateTime(1919, 02, 02), Name = "VfB Stuttgart", ArenaName = "Mercedez Benz Arena", ArenaCapacity = 68000, TransferBudget = 50000000 });
                    ctx.Clubs.Add(new Clubs { FoundingYear = new DateTime(1919, 02, 02), Name = "Eintracht Frankfurt", ArenaName = "Waldstadion", ArenaCapacity = 54000, TransferBudget = 40000000 });
                    ctx.SaveChanges();
                }
            }
        }
    }




    

}
