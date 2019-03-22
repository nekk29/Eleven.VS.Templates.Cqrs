using $ext_safesolutionname$.CrossCutting.Common.Loggin;
using $ext_safesolutionname$.Domain.Security.Entities;
using $ext_safesolutionname$.Repository.Entity.Core.Base;
using $ext_safesolutionname$.Repository.Interfaces.Security;

namespace $ext_safesolutionname$.Repository.Entity.Security
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ILogger logger) : base(logger)
        {

        }
    }
}
