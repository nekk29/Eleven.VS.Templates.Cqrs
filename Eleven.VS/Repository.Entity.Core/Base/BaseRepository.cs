using $ext_safesolutionname$.CrossCutting.Common.Loggin;
using $ext_safesolutionname$.Repository.Entity.Core.Contexts;
using $ext_safesolutionname$.Repository.Interfaces.Core.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace $ext_safesolutionname$.Repository.Entity.Core.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ILogger Logger { get; set; }

        public BaseRepository(ILogger logger)
        {
            Logger = logger;
        }
    
        public async Task Add(params T[] items)
        {
            try
            {
                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    context.Set<T>().AddRange(items);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public async Task Update(params T[] items)
        {
            try
            {
                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    foreach (T item in items)
                    {
                        context.Set<T>().Attach(item);
                        context.Entry(item).State = EntityState.Modified;
                    }
                    
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    
        public async Task Delete(params T[] items)
        {
            try
            {
                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    items.ToList().ForEach(item => context.Set<T>().Attach(item));
                    context.Set<T>().RemoveRange(items);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    
        public async Task<T> GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                T item = null;

                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    IQueryable<T> iQueryable = context.Set<T>();

                    if (where != null)
                        iQueryable = iQueryable.Where(where);

                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        iQueryable = iQueryable.Include(navigationProperty);
                    
                    item = await iQueryable.AsNoTracking().FirstOrDefaultAsync();
                }

                return item;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    
        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                List<T> list = new List<T>();

                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    IQueryable<T> iQueryable = context.Set<T>();

                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        iQueryable = iQueryable.Include(navigationProperty);
                    
                    list = await iQueryable.AsNoTracking().ToListAsync();
                }

                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    
        public async Task<List<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                List<T> list = new List<T>();

                using (var context = new $ext_mainconnectionname$DbContext())
                {
                    IQueryable<T> iQueryable = context.Set<T>();

                    if (where != null)
                        iQueryable = iQueryable.Where(where);

                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        iQueryable = iQueryable.Include(navigationProperty);
                    
                    list = await iQueryable.AsNoTracking().ToListAsync();
                }

                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }
    }
}
