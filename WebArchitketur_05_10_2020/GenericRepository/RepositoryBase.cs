using GenericRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GenericRepository
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {

        public RepositoryBase()
        {
        }

        public abstract int Count();

        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);

        public abstract void Delete(TEntity entity);

        public abstract IList<TEntity> GetAll();

        public abstract void Insert(TEntity entity);

        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);

        public abstract void Update(TEntity orginalEntity, TEntity modifiedEntity);

        public abstract IList<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        public abstract IQueryable<TEntity> All();
    }
}
