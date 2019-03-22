using $ext_safesolutionname$.Domain.Core.Entities;

namespace $ext_safesolutionname$.Domain.Security.Entities
{
    public class User : BaseEntity
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
