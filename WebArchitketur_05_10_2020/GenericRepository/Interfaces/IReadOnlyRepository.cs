using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        //Lese einen Datensatz aus der DB
        Task<TEntity> Single(Expression<Func<TEntity, bool>> predicate);

        //Lese eine Ergebnisliste aus der DB, nach einer Abfrage (wie ein select * from Tabellennamen Where [......])
        Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAll(); //Lese komplette Tabelle aus und gebe diese als Liste zurück
                                       //IEnumerable
                                       //Ist IQueryable ein geeigneter Datentyp.
        /* IQueryable<TEntity> All();*/ // Der böse Rückgabewert!!!

    }
}
