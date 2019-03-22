using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base;
using EnvDTE;
using System.Collections.Generic;
using System.Linq;
using VSLangProj;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager
{
    public class DataAccessReferenceManager : BaseReferenceManager
    {
        public DataAccessReferenceManager(string safeProjectName, IList<Project> projects) : base(safeProjectName, projects)
        {

        }

        public override void Configure()
        {
            Project projectCrossCuttingCommon = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("CrossCutting.Common"));

            Project projectDomainCoreDtos = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Core.Dtos"));
            Project projectDomainMainDtos = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Main.Dtos"));
            Project projectDomainSecurityDtos = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("Domain.Security.Dtos"));

            Project projectDataAccessInterfacesCore = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.Interfaces.Core"));
            Project projectDataAccessInterfacesMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.Interfaces.Main"));
            Project projectDataAccessInterfacesSecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.Interfaces.Security"));

            Project projectDataAccessNPocoCore = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.NPoco.Core"));
            Project projectDataAccessNPocoMain = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.NPoco.Main"));
            Project projectDataAccessNPocoSecurity = Projects.FirstOrDefault(x => x.Name == GetCompleteProjectNameBySufix("DataAccess.NPoco.Security"));

            #region Interfaces

            if (projectDataAccessInterfacesCore != null &&
                projectDomainCoreDtos != null)
            {
                VSProject vsProject = projectDataAccessInterfacesCore.Object as VSProject;
                vsProject.References.AddProject(projectDomainCoreDtos);
            }

            if (projectDataAccessInterfacesMain != null &&
                projectDataAccessInterfacesCore != null &&
                projectDomainCoreDtos != null &&
                projectDomainMainDtos != null)
            {
                VSProject vsProject = projectDataAccessInterfacesMain.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessInterfacesCore);
                vsProject.References.AddProject(projectDomainCoreDtos);
                vsProject.References.AddProject(projectDomainMainDtos);
            }

            if (projectDataAccessInterfacesSecurity != null &&
                projectDataAccessInterfacesCore != null &&
                projectDomainCoreDtos != null &&
                projectDomainSecurityDtos != null)
            {
                VSProject vsProject = projectDataAccessInterfacesSecurity.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessInterfacesCore);
                vsProject.References.AddProject(projectDomainCoreDtos);
                vsProject.References.AddProject(projectDomainSecurityDtos);
            }

            #endregion

            #region Implementation

            if (projectDataAccessNPocoCore != null &&
                projectCrossCuttingCommon != null &&
                projectDataAccessInterfacesCore != null &&
                projectDomainCoreDtos != null)
            {
                VSProject vsProject = projectDataAccessNPocoCore.Object as VSProject;
                vsProject.References.AddProject(projectCrossCuttingCommon);
                vsProject.References.AddProject(projectDataAccessInterfacesCore);
                vsProject.References.AddProject(projectDomainCoreDtos);
            }

            if (projectDataAccessNPocoMain != null &&
                projectDataAccessNPocoCore != null &&
                projectDataAccessInterfacesCore != null &&
                projectDataAccessInterfacesMain != null &&
                projectDomainCoreDtos != null &&
                projectDomainMainDtos != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDataAccessNPocoMain.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessNPocoCore);
                vsProject.References.AddProject(projectDataAccessInterfacesCore);
                vsProject.References.AddProject(projectDataAccessInterfacesMain);
                vsProject.References.AddProject(projectDomainCoreDtos);
                vsProject.References.AddProject(projectDomainMainDtos);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            if (projectDataAccessNPocoSecurity != null &&
                projectDataAccessNPocoCore != null &&
                projectDataAccessInterfacesCore != null &&
                projectDataAccessInterfacesSecurity != null &&
                projectDomainCoreDtos != null &&
                projectDomainSecurityDtos != null &&
                projectCrossCuttingCommon != null)
            {
                VSProject vsProject = projectDataAccessNPocoSecurity.Object as VSProject;
                vsProject.References.AddProject(projectDataAccessNPocoCore);
                vsProject.References.AddProject(projectDataAccessInterfacesCore);
                vsProject.References.AddProject(projectDataAccessInterfacesSecurity);
                vsProject.References.AddProject(projectDomainCoreDtos);
                vsProject.References.AddProject(projectDomainSecurityDtos);
                vsProject.References.AddProject(projectCrossCuttingCommon);
            }

            #endregion
        }
    }
}
