using GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public RepositoryBase()
        {
        }

        public abstract Task<int> Count();

        public abstract Task Delete(Expression<Func<TEntity, bool>> predicate);

        public abstract Task Delete(TEntity entity);

        public abstract Task<List<TEntity>> GetAll();

        public abstract Task Insert(TEntity entity);

        public abstract Task<TEntity> Single(Expression<Func<TEntity, bool>> predicate);

        public abstract Task Update(TEntity orginalEntity, TEntity modifiedEntity);

        public abstract Task Update(TEntity modifiedEntity);
        

        public abstract Task<List<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        //public abstract IQueryable<TEntity> All();
    }
}
