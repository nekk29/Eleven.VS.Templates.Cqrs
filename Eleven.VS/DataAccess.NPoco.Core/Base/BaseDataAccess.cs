using $ext_safesolutionname$.CrossCutting.Common.Loggin;
using $ext_safesolutionname$.DataAccess.Interfaces.Core.Base;
using $ext_safesolutionname$.DataAccess.NPoco.Core.Databases;
using $ext_safesolutionname$.DataAccess.NPoco.Core.Resources;
using $ext_safesolutionname$.Domain.Core.Dtos;
using NPoco;
using NPoco.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace $ext_safesolutionname$.DataAccess.NPoco.Core.Base
{
    public class BaseDataAccess<T> : IBaseDataAccess<T> where T : class
    {
        private ILogger Logger { get; set; }

        public BaseDataAccess(ILogger logger)
        {
            Logger = logger;
        }
    
        public async Task<T> GetSingle(Expression<Func<T, bool>> where)
        {
            try
            {
                using (var database = new $ext_mainconnectionname$Database())
                {
                    return await database.Query<T>().Where(where).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                using (var database = new $ext_mainconnectionname$Database())
                {
                    return await database.FetchAsync<T>();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> where)
        {
            try
            {
                using (var database = new $ext_mainconnectionname$Database())
                {
                    return await database.Query<T>().Where(where).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    
        public async Task<PageResult<T>> GetPagedList(long current, long rowCount, Expression<Func<T, bool>> where, Expression<Func<T, object>> orderByExpression, bool ascending)
        {
            try
            {
                if (current <= 0)
                    throw new ArgumentException(Messages.NonValidPageNumber, "current");

                if (rowCount <= 0)
                    throw new ArgumentException(Messages.NonValidPageSize, "rowCount");

                if (orderByExpression == null)
                    throw new ArgumentNullException("orderByExpression", Messages.NonNullOrderExpression);

                using (var database = new $ext_mainconnectionname$Database())
                {
                    IQueryProvider<T> queryProvider = null;

                    if(ascending)
                        queryProvider = database.Query<T>().Where(where).OrderBy(orderByExpression);
                    else
                        queryProvider = database.Query<T>().Where(where).OrderByDescending(orderByExpression);

                    var sentence = new Sql(queryProvider.ToString());
                
                    var result = await database.PageAsync<T>(current, rowCount, sentence);
                
                    return new PageResult<T>()
                    {
                        CurrentPage = result.CurrentPage,
                        TotalPages = result.TotalPages,
                        TotalItems = result.TotalItems,
                        ItemsPerPage = result.ItemsPerPage,
                        Items = result.Items
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
