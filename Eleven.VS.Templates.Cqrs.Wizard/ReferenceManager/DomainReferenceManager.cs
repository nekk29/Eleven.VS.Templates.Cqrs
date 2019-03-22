using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base;
using EnvDTE;
using System.Collections.Generic;
using System.Linq;
using VSLangProj;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager
{
    public class DomainReferenceManager : BaseReferenceManager
    {
        public DomainReferenceManager(string safeProjectName, IList<Project> projects) : base(safeProjectName, projects)
        {

        }

        public override void Configure()
        {
            Project projectDomainCoreEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Core.Entities"));
            Project projectDomainMainEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Entities"));
            Project projectDomainSecurityEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Entities"));

            if (projectDomainCoreEntities != null && projectDomainMainEntities != null)
            {
                VSProject vsProject = projectDomainMainEntities.Object as VSProject;
                vsProject.References.AddProject(projectDomainCoreEntities);
            }

            if (projectDomainCoreEntities != null && projectDomainSecurityEntities != null)
            {
                VSProject vsProject = projectDomainSecurityEntities.Object as VSProject;
                vsProject.References.AddProject(projectDomainCoreEntities);
            }
        }
    }
}
