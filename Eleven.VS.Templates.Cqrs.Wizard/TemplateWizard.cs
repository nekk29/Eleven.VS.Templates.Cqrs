using Eleven.VS.Templates.Cqrs.Wizard.Dialogs;
using Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager;
using Eleven.VS.Templates.Cqrs.Wizard.Resources;
using Eleven.VS.Templates.Cqrs.Wizard.Shared;
using Eleven.VS.Templates.Cqrs.Wizard.Utils;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eleven.VS.Templates.Cqrs.Wizard
{
    public class TemplateWizardResourcesWizard : IWizard
    {
        private _DTE dte;

        private bool IsSolution = true;
        private string SafeProjectName;

        private ProjectSettings ProjectSettings;
        private ProjectSettingsDialog ProjectSettingsDialog;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {
            try
            {
                Solution2 solution2 = (Solution2)dte.Solution;
                IList<Project> projects = SolutionUtils.GetAllProjectsInSolution(solution2);

                new DomainReferenceManager(SafeProjectName, projects).Configure();
                new RepositoryReferenceManager(SafeProjectName, projects).Configure();
                new DataAccessReferenceManager(SafeProjectName, projects).Configure();
                new CommandReferenceManager(SafeProjectName, projects).Configure();
                new QueryReferenceManager(SafeProjectName, projects).Configure();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show(ex.Message);
                else
                    MessageBox.Show(ex.InnerException.Message);
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            dte = automationObject as _DTE;

            ProjectSettings = new ProjectSettings();
            ProjectSettingsDialog = new ProjectSettingsDialog(ProjectSettings);
            ProjectSettingsDialog.ShowDialog();

            if (IsSolution)
            {
                InitializeReplacementsDictionary(replacementsDictionary, ProjectSettings);
                IsSolution = false;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        private void InitializeReplacementsDictionary(Dictionary<string, string> replacementsDictionary, ProjectSettings projectSettings)
        {
            SafeProjectName = replacementsDictionary["$safeprojectname$"];

            replacementsDictionary["$safesolutionname$"] = replacementsDictionary["$safeprojectname$"];

            //Project Settings
            replacementsDictionary["$mainconnectionname$"] = projectSettings.ConnectionSettings.ConnectionName;
            replacementsDictionary["$mainconnectionstring$"] = projectSettings.ConnectionSettings.ConnectionString;

            //0 Modeling and Design
            replacementsDictionary["$a_solutionfoldermodeling$"] = TemplateWizardResources.A_SolutionFolder_Modeling;

            //1 Layers
            replacementsDictionary["$b_solutionfolderlayers$"] = TemplateWizardResources.B_SolutionFolder_Layers;
            //1 Layers -> 1.1 Presentation
            replacementsDictionary["$b_solutionfolderlayers_1_presentation$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation;
            //1 Layers -> 1.1 Presentation -> 1.1.1 Mobile
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_1_mobile$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_1_Mobile;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_1_mobile_xamarin$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_1_Mobile_1_Xamarin;
            //1 Layers -> 1.1 Presentation -> 1.1.2 RIA
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_2_ria$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_2_RIA;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_2_ria_silverlightclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_2_RIA_1_SilverlightClient;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_2_ria_silverlightmobile$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_2_RIA_2_SilverlightMobile;
            //1 Layers -> 1.1 Presentation -> 1.1.3 Web
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_3_web$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_3_Web;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_3_web_angularclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_3_Web_1_AngularClient;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_3_web_aspnetclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_3_Web_2_AspNetClient;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_3_web_aspnetmvcclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_3_Web_3_AspNetMvcClient;
            //1 Layers -> 1.1 Presentation -> 1.1.4 Windows
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_4_windows$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_4_Windows;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_4_windows_obaclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_4_Windows_1_ObaClient;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_4_windows_winformclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_4_Windows_2_WinFormClient;
            replacementsDictionary["$b_solutionfolderlayers_1_presentation_4_windows_wpfclient$"] = TemplateWizardResources.B_SolutionFolder_Layers_1_Presentation_4_Windows_3_WpfClient;
            //1 Layers -> 1.2 Distributed Services
            replacementsDictionary["$b_solutionfolderlayers_2_distributedservices$"] = TemplateWizardResources.B_SolutionFolder_Layers_2_DistributedServices;
            //1 Layers -> 1.2 Distributed Services -> 1.2.1 Core
            replacementsDictionary["$b_solutionfolderlayers_2_distributedservices_1_core$"] = TemplateWizardResources.B_SolutionFolder_Layers_2_DistributedServices_1_Core;
            //1 Layers -> 1.2 Distributed Services -> 1.2.2 Main
            replacementsDictionary["$b_solutionfolderlayers_2_distributedservices_2_main$"] = TemplateWizardResources.B_SolutionFolder_Layers_2_DistributedServices_2_Main;
            //1 Layers -> 1.2 Distributed Services -> 1.2.3 Security
            replacementsDictionary["$b_solutionfolderlayers_2_distributedservices_3_security$"] = TemplateWizardResources.B_SolutionFolder_Layers_2_DistributedServices_3_Security;
            //1 Layers -> 1.2 Distributed Services -> 1.2.4 Deployment
            replacementsDictionary["$b_solutionfolderlayers_2_distributedservices_4_deployment$"] = TemplateWizardResources.B_SolutionFolder_Layers_2_DistributedServices_4_Deployment;
            //1 Layers -> 1.3 Application
            replacementsDictionary["$b_solutionfolderlayers_3_application$"] = TemplateWizardResources.B_SolutionFolder_Layers_3_Application;
            //1 Layers -> 1.3 Application -> 1.3.1 Core
            replacementsDictionary["$b_solutionfolderlayers_3_application_1_core$"] = TemplateWizardResources.B_SolutionFolder_Layers_3_Application_1_Core;
            //1 Layers -> 1.3 Application -> 1.3.2 Main
            replacementsDictionary["$b_solutionfolderlayers_3_application_2_main$"] = TemplateWizardResources.B_SolutionFolder_Layers_3_Application_2_Main;
            //1 Layers -> 1.3 Application -> 1.3.3 Security
            replacementsDictionary["$b_solutionfolderlayers_3_application_3_security$"] = TemplateWizardResources.B_SolutionFolder_Layers_3_Application_3_Security;
            //1 Layers -> 1.4 Domain
            replacementsDictionary["$b_solutionfolderlayers_4_domain$"] = TemplateWizardResources.B_SolutionFolder_Layers_4_Domain;
            //1 Layers -> 1.4 Domain -> 1.4.1 Core
            replacementsDictionary["$b_solutionfolderlayers_4_domain_1_core$"] = TemplateWizardResources.B_SolutionFolder_Layers_4_Domain_1_Core;
            //1 Layers -> 1.4 Domain -> 1.4.2 Main
            replacementsDictionary["$b_solutionfolderlayers_4_domain_2_main$"] = TemplateWizardResources.B_SolutionFolder_Layers_4_Domain_2_Main;
            //1 Layers -> 1.4 Domain -> 1.4.3 Security
            replacementsDictionary["$b_solutionfolderlayers_4_domain_3_security$"] = TemplateWizardResources.B_SolutionFolder_Layers_4_Domain_3_Security;
            //1 Layers -> 1.5 Infraestructure
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure;
            //1 Layers -> 1.5 Infraestructure -> 1.5.1 Data
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_repository$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_Repository;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_repository_interfaces$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_Repository_Interfaces;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_repository_implementation$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_Repository_Implementation;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_dataaccess$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_DataAccess;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_dataaccess_interfaces$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_DataAccess_Interfaces;
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_1_data_dataaccess_implementation$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_1_Data_DataAccess_Implementation;
            //1 Layers -> 1.5 Infraestructure -> 1.5.2 Cross Cutting
            replacementsDictionary["$b_solutionfolderlayers_5_infraestructure_2_crosscutting$"] = TemplateWizardResources.B_SolutionFolder_Layers_5_Infraestructure_2_CrossCutting;

            //2 Database
            replacementsDictionary["$c_solutionfolderdatabase$"] = TemplateWizardResources.C_SolutionFolder_Database;

            //3 Solution Items
            replacementsDictionary["$d_solutionfoldersolutionitems$"] = TemplateWizardResources.D_SolutionFolder_SolutionItems;
        }
    }
}
