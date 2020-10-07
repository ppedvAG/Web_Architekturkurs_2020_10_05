using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces.Traits
{
    public interface ICanAdd<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity);
    }
}
