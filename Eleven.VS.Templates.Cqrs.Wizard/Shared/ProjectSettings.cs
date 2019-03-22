namespace Eleven.VS.Templates.Cqrs.Wizard.Shared
{
    public class ProjectSettings
    {
        public ConnectionSettings ConnectionSettings { get; set; }

        public ProjectSettings()
        {
            ConnectionSettings = new ConnectionSettings();
        }
    }
}
