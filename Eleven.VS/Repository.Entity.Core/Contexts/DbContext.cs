using $ext_safesolutionname$.Domain.Security.Entities;
using System.Data.Entity;

namespace $ext_safesolutionname$.Repository.Entity.Core.Contexts
{
    public class $ext_mainconnectionname$DbContext : DbContext
    {
        public $ext_mainconnectionname$DbContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        #region Security
        public DbSet<User> User { get; set; }
        #endregion
    }
}
