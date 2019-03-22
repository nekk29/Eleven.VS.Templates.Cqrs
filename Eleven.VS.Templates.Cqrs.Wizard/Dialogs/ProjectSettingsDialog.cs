using Eleven.VS.Templates.Cqrs.Wizard.Shared;
using Microsoft.Data.ConnectionUI;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Eleven.VS.Templates.Cqrs.Wizard.Dialogs
{
    public partial class ProjectSettingsDialog : Form
    {
        private DataSource DataSource;
        private DataConnectionDialog DataConnectionDialog { get; set; }

        private ProjectSettings ProjectSettings { get; set; }

        public ProjectSettingsDialog(ProjectSettings projectSettings)
        {
            InitializeComponent();
            Initialize(projectSettings);
        }

        private void Initialize(ProjectSettings projectSettings)
        {
            ProjectSettings = projectSettings;
        }

        private void btnConnectionString_Click(object sender, EventArgs e)
        {
            OpenDataConnectionDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidSettings())
            {
                ProjectSettings.ConnectionSettings.ConnectionName = txtConnectionName.Text;
                ProjectSettings.ConnectionSettings.ConnectionString = txtConnectionString.Text;

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ValidSettings())
            {
                Close();
            }
        }

        private void ProjectSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidSettings()) e.Cancel = true;
        }

        private void OpenDataConnectionDialog()
        {
            DataSource = new DataSource("MicrosoftSqlServer", "Package Builder Providers");
            DataSource.Providers.Add(DataProvider.OdbcDataProvider);
            DataSource.Providers.Add(DataProvider.OleDBDataProvider);
            DataSource.Providers.Add(DataProvider.OracleDataProvider);
            DataSource.Providers.Add(DataProvider.SqlDataProvider);

            DataConnectionDialog = new DataConnectionDialog();
            DataConnectionDialog.DataSources.Add(DataSource);
            DataConnectionDialog.SelectedDataProvider = DataProvider.SqlDataProvider;
            DataConnectionDialog.SelectedDataSource = DataSource;
            DataConnectionDialog.ConnectionString = String.Empty;

            try
            {
                DataConnectionDialog.ConnectionString = txtConnectionString.Text;
            }
            catch (Exception)
            {
                DataConnectionDialog.ConnectionString = String.Empty;
            }

            DataConnectionDialog.Show(DataConnectionDialog);

            txtConnectionString.Text = DataConnectionDialog.ConnectionString;

            try
            {
                SqlConnection oSqlConnection = new SqlConnection(txtConnectionString.Text);
                txtConnectionName.Text = oSqlConnection.Database;
            }
            catch (Exception)
            {
                DataConnectionDialog.ConnectionString = String.Empty;
            }
        }

        private bool ValidSettings()
        {
            bool validSettings;

            validSettings = ValidDatabaseSettings();

            return validSettings;
        }
        private bool ValidDatabaseSettings()
        {
            bool validSettings = true;

            if (string.IsNullOrEmpty(txtConnectionString.Text))
            {
                SetTextFieldValidationMessage(txtConnectionString, ToolTipIcon.Warning, "Required", "Type a connection string");
                validSettings = false;
            }

            if (string.IsNullOrEmpty(txtConnectionName.Text))
            {
                SetTextFieldValidationMessage(txtConnectionName, ToolTipIcon.Warning, "Required", "Type a connection name");
                validSettings = false;
            }

            return validSettings;
        }

        private void SetTextFieldValidationMessage(TextBox textBox, ToolTipIcon toolTipIcon, string title, string message)
        {
            int visibleTime = 2500;

            int x = textBox.Width;
            int y = 0;

            ToolTip toolTip = new ToolTip();

            toolTip.ToolTipTitle = title;
            toolTip.ToolTipIcon = toolTipIcon;

            toolTip.Show(message, textBox, x, y, visibleTime);
        }
    }
}
