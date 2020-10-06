using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanAdd<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
    }
}
