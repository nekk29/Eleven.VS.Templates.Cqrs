namespace Eleven.VS.Templates.Cqrs.Wizard.Dialogs
{
    partial class ProjectSettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxDataBaseSettings = new System.Windows.Forms.GroupBox();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.lblConnectionName = new System.Windows.Forms.Label();
            this.btnConnectionString = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.lblProjectSettings = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbxDataBaseSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDataBaseSettings
            // 
            this.gbxDataBaseSettings.Controls.Add(this.txtConnectionName);
            this.gbxDataBaseSettings.Controls.Add(this.lblConnectionName);
            this.gbxDataBaseSettings.Controls.Add(this.btnConnectionString);
            this.gbxDataBaseSettings.Controls.Add(this.txtConnectionString);
            this.gbxDataBaseSettings.Controls.Add(this.lblConnectionString);
            this.gbxDataBaseSettings.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDataBaseSettings.Location = new System.Drawing.Point(12, 41);
            this.gbxDataBaseSettings.Name = "gbxDataBaseSettings";
            this.gbxDataBaseSettings.Size = new System.Drawing.Size(676, 95);
            this.gbxDataBaseSettings.TabIndex = 10;
            this.gbxDataBaseSettings.TabStop = false;
            this.gbxDataBaseSettings.Text = "Database Settings";
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionName.Location = new System.Drawing.Point(131, 58);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(488, 25);
            this.txtConnectionName.TabIndex = 4;
            // 
            // lblConnectionName
            // 
            this.lblConnectionName.AutoSize = true;
            this.lblConnectionName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionName.Location = new System.Drawing.Point(6, 61);
            this.lblConnectionName.Name = "lblConnectionName";
            this.lblConnectionName.Size = new System.Drawing.Size(119, 19);
            this.lblConnectionName.TabIndex = 3;
            this.lblConnectionName.Text = "Connection Name";
            // 
            // btnConnectionString
            // 
            this.btnConnectionString.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectionString.Location = new System.Drawing.Point(625, 27);
            this.btnConnectionString.Name = "btnConnectionString";
            this.btnConnectionString.Size = new System.Drawing.Size(45, 25);
            this.btnConnectionString.TabIndex = 2;
            this.btnConnectionString.Text = "...";
            this.btnConnectionString.UseVisualStyleBackColor = true;
            this.btnConnectionString.Click += new System.EventHandler(this.btnConnectionString_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionString.Location = new System.Drawing.Point(131, 27);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(488, 25);
            this.txtConnectionString.TabIndex = 1;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionString.Location = new System.Drawing.Point(6, 30);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(119, 19);
            this.lblConnectionString.TabIndex = 0;
            this.lblConnectionString.Text = "Connection String";
            // 
            // lblProjectSettings
            // 
            this.lblProjectSettings.AutoSize = true;
            this.lblProjectSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectSettings.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProjectSettings.Location = new System.Drawing.Point(12, 10);
            this.lblProjectSettings.Name = "lblProjectSettings";
            this.lblProjectSettings.Size = new System.Drawing.Size(119, 20);
            this.lblProjectSettings.TabIndex = 9;
            this.lblProjectSettings.Text = "Project Settings";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(534, 142);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(615, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProjectSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 183);
            this.Controls.Add(this.gbxDataBaseSettings);
            this.Controls.Add(this.lblProjectSettings);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProjectSettingsDialog";
            this.Text = "Project Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectSettingsDialog_FormClosing);
            this.gbxDataBaseSettings.ResumeLayout(false);
            this.gbxDataBaseSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDataBaseSettings;
        private System.Windows.Forms.TextBox txtConnectionName;
        private System.Windows.Forms.Label lblConnectionName;
        private System.Windows.Forms.Button btnConnectionString;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Label lblProjectSettings;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}