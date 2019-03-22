using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base;
using EnvDTE;
using System.Collections.Generic;
using System.Linq;
using VSLangProj;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager
{
    public class RepositoryReferenceManager : BaseReferenceManager
    {
        public RepositoryReferenceManager(string safeProjectName, IList<Project> projects) : base(safeProjectName, projects)
        {

        }

        public override void Configure()
        {
            Project projectCrossCuttingCommon = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("CrossCutting.Common"));

            Project projectDomainMainEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Entities"));
            Project projectDomainSecurityEntities = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Entities"));

            Project projectRepositoryInterfacesCore = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Interfaces.Core"));
            Project projectRepositoryInterfacesMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Interfaces.Main"));
            Project projectRepositoryInterfacesSecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Interfaces.Security"));

            Project projectRepositoryEntityCore = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Entity.Core"));
            Project projectRepositoryEntityMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Entity.Main"));
            Project projectRepositoryEntitySecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Repository.Entity.Security"));

            #region Interfaces

            if (projectRepositoryInterfacesMain != null &&
                projectRepositoryInterfacesCore != null &&
                projectDomainMainEntities != null)
            {
                VSProject vsProject = projectRepositoryInterfacesMain.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryInterfacesCore);
                vsProject.References.AddProject(projectDomainMainEntities);
            }

            if (projectRepositoryInterfacesSecurity != null &&
                projectRepositoryInterfacesCore != null &&
                projectDomainSecurityEntities != null)
            {
                VSProject vsProject = projectRepositoryInterfacesSecurity.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryInterfacesCore);
                vsProject.References.AddProject(projectDomainSecurityEntities);
            }

            #endregion

            #region Implementation

            if (projectRepositoryEntityCore != null &&
                projectCrossCuttingCommon != null &&
                projectRepositoryInterfacesCore != null &&
                projectDomainMainEntities != null &&
                projectDomainSecurityEntities != null)
            {
                VSProject vsProject = projectRepositoryEntityCore.Object as VSProject;
                vsProject.References.AddProject(projectCrossCuttingCommon);
                vsProject.References.AddProject(projectRepositoryInterfacesCore);
                vsProject.References.AddProject(projectDomainMainEntities);
                vsProject.References.AddProject(projectDomainSecurityEntities);
            }

            if (projectRepositoryEntityMain != null &&
                projectRepositoryEntityCore != null &&
                projectRepositoryInterfacesCore != null &&
                projectRepositoryInterfacesMain != null &&
                projectDomainMainEntities != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectRepositoryEntityMain.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryEntityCore);
                vsProject.References.AddProject(projectRepositoryInterfacesCore);
                vsProject.References.AddProject(projectRepositoryInterfacesMain);
                vsProject.References.AddProject(projectDomainMainEntities);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            if (projectRepositoryEntitySecurity != null &&
                projectRepositoryEntityCore != null &&
                projectRepositoryInterfacesCore != null &&
                projectRepositoryInterfacesSecurity != null &&
                projectDomainSecurityEntities != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectRepositoryEntitySecurity.Object as VSProject;
                vsProject.References.AddProject(projectRepositoryEntityCore);
                vsProject.References.AddProject(projectRepositoryInterfacesCore);
                vsProject.References.AddProject(projectRepositoryInterfacesSecurity);
                vsProject.References.AddProject(projectDomainSecurityEntities);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            #endregion
        }
    }
}
