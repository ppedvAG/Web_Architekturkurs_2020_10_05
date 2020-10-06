using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanDelete<TEntity> where TEntity : class
    {
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
    }
}
