using GenericRepository.Interfaces;
using RepositoryImpl.Entities;
using RepositoryImpl.Repositories;
using System;

namespace AppUsedRepositoryImpl
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kann alles
            IRepository<Clubs> repository = new ClubRepository();


            //Readonly 
            IReadOnlyRepository<Clubs> readReposiotry = new ClubRepository();
        }
    }
}
