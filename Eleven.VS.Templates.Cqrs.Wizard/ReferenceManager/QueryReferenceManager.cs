using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base;
using EnvDTE;
using System.Collections.Generic;
using System.Linq;
using VSLangProj;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager
{
    public class QueryReferenceManager : BaseReferenceManager
    {
        public QueryReferenceManager(string safeProjectName, IList<Project> projects) : base(safeProjectName, projects)
        {

        }

        public override void Configure()
        {
            Project projectCrossCuttingCommon = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("CrossCutting.Common"));

            Project projectDomainMainDtos = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Dtos"));
            Project projectDomainSecurityDtos = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Dtos"));

            Project projectDataAccessInterfacesMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.Interfaces.Main"));
            Project projectDataAccessInterfacesSecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.Interfaces.Security"));

            Project projectDomainMainQuery = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Query"));
            Project projectDomainSecurityQuery = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Query"));

            if (projectDomainMainQuery != null &&
                projectDataAccessInterfacesMain != null &&
                projectDomainMainDtos != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDomainMainQuery.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessInterfacesMain);
                vsProject.References.AddProject(projectDomainMainDtos);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            if (projectDomainSecurityQuery != null &&
                projectDataAccessInterfacesSecurity != null &&
                projectDomainSecurityDtos != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDomainSecurityQuery.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessInterfacesSecurity);
                vsProject.References.AddProject(projectDomainSecurityDtos);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }
        }
    }
}
