using EnvDTE;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Cqrs.Wizard.ReferenceManager.Base
{
    public abstract class BaseReferenceManager
    {
        private string SafeProjectName;
        protected IList<Project> Projects;

        public BaseReferenceManager(string safeProjectName, IList<Project> projects)
        {
            SafeProjectName = safeProjectName;
            Projects = projects;
        }

        public abstract void Configure();

        protected string GetCompleteProjectNameBySufix(string projectSufix)
        {
            return string.Concat(SafeProjectName, ".", projectSufix);
        }
    }
}
