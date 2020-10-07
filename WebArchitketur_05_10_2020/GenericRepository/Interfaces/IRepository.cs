using GenericRepository.Interfaces.Traits;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IRepository<TEntity> :
        IReadOnlyRepository<TEntity>,
        ICanAdd<TEntity>,
        ICanUpdate<TEntity>,
        ICanDelete<TEntity> where TEntity : class
    {
        Task<int> Count();



        //Bei Unit of Work wäre in diesem Interface sicher eine Commit-Methode -> void Commit();
    }
}
