using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanUpdate<TEntity> where TEntity : class
    {
        Task Update(TEntity orginalEntity, TEntity modifiedEntity);

        Task Update(TEntity modifiedEntity);

        //public interface ICanUpdate<TEntity, TKey> where TEntity : class  + void Update(TKey orginalId, TEntity modifiedEntity);
    }
}
