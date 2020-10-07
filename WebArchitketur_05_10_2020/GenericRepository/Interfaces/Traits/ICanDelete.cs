using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanDelete<TEntity> where TEntity : class
    {
        Task Delete(Expression<Func<TEntity, bool>> predicate);
        Task Delete(TEntity entity);
    }
}
