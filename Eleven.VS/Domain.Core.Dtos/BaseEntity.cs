using System;
using System.Threading;

namespace $ext_safesolutionname$.Domain.Core.Entities
{
    public class BaseEntity
    {
        public string CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public BaseEntity()
        {
            UpdateAuditFields();
        }

        public void UpdateAuditFields()
        {
            if (string.IsNullOrEmpty(CreationUser))
            {
                CreationUser = Thread.CurrentPrincipal.Identity.Name;
                CreationDate = DateTime.Now;
                Active = true;
            }

            UpdateUser = Thread.CurrentPrincipal.Identity.Name;
            UpdateDate = DateTime.Now;
        }
    }
}
