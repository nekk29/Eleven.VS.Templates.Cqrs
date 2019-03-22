using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base;
using EnvDTE;
using System.Collections.Generic;
using System.Linq;
using VSLangProj;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager
{
    public class CommandReferenceManager : BaseReferenceManager
    {
        public CommandReferenceManager(string safeProjectName, IList<Project> projects) : base(safeProjectName, projects)
        {

        }

        public override void Configure()
        {
            Project projectCrossCuttingCommon = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("CrossCutting.Common"));

            Project projectDomainMainEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Entities"));
            Project projectDomainSecurityEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Entities"));

            Project projectRepositoryInterfacesMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Interfaces.Main"));
            Project projectRepositoryInterfacesSecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Interfaces.Security"));

            Project projectDomainMainCommand = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Command"));
            Project projectDomainSecurityCommand = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Command"));

            if (projectDomainMainCommand != null &&
                projectRepositoryInterfacesMain != null &&
                projectDomainMainEntities != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDomainMainCommand.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryInterfacesMain);
                vsProject.References.AddProject(projectDomainMainEntities);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            if (projectDomainSecurityCommand != null &&
                projectRepositoryInterfacesSecurity != null &&
                projectDomainSecurityEntities != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDomainSecurityCommand.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryInterfacesSecurity);
                vsProject.References.AddProject(projectDomainSecurityEntities);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }
        }
    }
}
