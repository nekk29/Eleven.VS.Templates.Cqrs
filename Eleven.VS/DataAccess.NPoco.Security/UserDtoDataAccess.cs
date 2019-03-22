using $ext_safesolutionname$.CrossCutting.Common.Loggin;
using $ext_safesolutionname$.DataAccess.Interfaces.Security;
using $ext_safesolutionname$.DataAccess.NPoco.Core.Base;
using $ext_safesolutionname$.Domain.Security.Dtos;

namespace $ext_safesolutionname$.DataAccess.NPoco.Security
{
    public class UserDtoDataAccess : BaseDataAccess<UserDto>, IUserDtoDataAccess
    {
        public UserDtoDataAccess(ILogger logger) : base(logger)
        {

        }
    }
}
