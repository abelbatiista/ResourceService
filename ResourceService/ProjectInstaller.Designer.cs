
namespace ResourceService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resourceServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.resourceServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // resourceServiceProcessInstaller
            //
            this.resourceServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.resourceServiceProcessInstaller.Password = null;
            this.resourceServiceProcessInstaller.Username = null;
            // 
            // resourceServiceInstaller
            // 
            this.resourceServiceInstaller.ServiceName = "ResourceServiceMainClass";
            this.resourceServiceInstaller.DisplayName = "Resource Service";
            this.resourceServiceInstaller.Description = "This service checks the RAM memory, Disk, and other pc components to verify if they are working well.";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.resourceServiceProcessInstaller,
            this.resourceServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller resourceServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller resourceServiceInstaller;
    }
}