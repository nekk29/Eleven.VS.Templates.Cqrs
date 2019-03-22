using $ext_safesolutionname$.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace $ext_safesolutionname$.DataAccess.Interfaces.Core.Base
{
    public interface IBaseDataAccess<T> where T : class
    {
        Task<T> GetSingle(Expression<Func<T, bool>> where);
        Task<List<T>> GetAll();
        Task<List<T>> GetList(Expression<Func<T, bool>> where);
        Task<PageResult<T>> GetPagedList(long current, long rowCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderByExpression, bool ascending);
    }
}
