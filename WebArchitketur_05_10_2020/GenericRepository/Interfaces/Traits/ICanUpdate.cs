using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanUpdate<TEntity> where TEntity : class
    {
        void Update(TEntity orginalEntity, TEntity modifiedEntity);

        //public interface ICanUpdate<TEntity, TKey> where TEntity : class  + void Update(TKey orginalId, TEntity modifiedEntity);
    }
}
