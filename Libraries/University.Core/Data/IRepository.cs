using System;
using System.Threading.Tasks;

namespace University.Core.Data
{
    public interface IRepository<TEntity> where TEntity :  class
    {
        Task<TEntity> GetById(object id);
        void Insert(TEntity entity);
    }
}
