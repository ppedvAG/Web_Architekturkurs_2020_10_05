using DatabaseFirstSampleWitEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstSampleWitEF
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAllDataSetsInDB();

            #region Hinzufügen eines neuen Datensatzes
            Movie newMovie = new Movie() { Title = "Kevin allein zu hause 3", Genre = "Familienfilm", Price = 12, ReleaseDate = DateTime.Now };

            using (MovieDBCtx ctx = new MovieDBCtx())
            {

                ctx.Movie.Add(newMovie);
                ctx.SaveChanges(); 
            }
            #endregion


            #region Hinzufügen eines neuen Datensatzes


            IList<Movie> newMovieListe = new List<Movie>();

            newMovieListe.Add(new Movie() { Title = "Robin Hood", Genre = "Abentuer", Price = 5, ReleaseDate = DateTime.Now });
            newMovieListe.Add(new Movie() { Title = "Leben des Brain", Genre = "Komödie", Price = 7, ReleaseDate = DateTime.Now });
            newMovieListe.Add(new Movie() { Title = "Ritter Kokusnuss", Genre = "Komödie", Price = 7, ReleaseDate = DateTime.Now });



            using (MovieDBCtx ctx = new MovieDBCtx())
            {
                foreach (Movie currentMovie in newMovieListe)
                {
                    ctx.Movie.Add(currentMovie);
                }
                ctx.SaveChanges(); 

                //Save Change wird zum Schluss aufgerufen. -> Entity Framework unterstützt das UnitOfWork-Pattern 
            }


            #endregion


            ReadAllDataSetsInDB();

            Console.ReadKey();
        }

        public static void ReadAllDataSetsInDB ()
        {
            #region Auslesen Aller Datensätze in EF
            IList<Movie> resultList = new List<Movie>();

            using (MovieDBCtx ctx = new MovieDBCtx())
            {

                resultList = ctx.Movie.ToList();
            }

            foreach (Movie currentMovie in resultList)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($" Id: {currentMovie.ID} Name: {currentMovie.Title}");
                Console.WriteLine($" Genre {currentMovie.Genre}");
                Console.WriteLine($" Preis: {currentMovie.Price}");
            }
            #endregion
        }
    }
}
