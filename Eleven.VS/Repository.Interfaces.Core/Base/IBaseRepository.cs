using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace $ext_safesolutionname$.Repository.Interfaces.Core.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(params T[] items);
        Task Update(params T[] items);
        Task Delete(params T[] items);
        Task<T> GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        Task<List<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
