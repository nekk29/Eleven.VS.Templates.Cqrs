using System;

namespace $ext_safesolutionname$.Domain.Security.Dtos
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
