
namespace UI.GimmeAScreenshotPleaseUI
{
    partial class GimmeAScreenshotPleaseForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GimmeAScreenshotPleaseForm));
            this.label1 = new System.Windows.Forms.Label();
            this.dfTarget = new System.Windows.Forms.TextBox();
            this.bindingSourceViewModel = new System.Windows.Forms.BindingSource(this.components);
            this.buttonListen = new System.Windows.Forms.Button();
            this.pbGet = new System.Windows.Forms.Button();
            this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
            this.panelTop.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.groupBoxClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target:";
            // 
            // dfTarget
            // 
            this.dfTarget.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceViewModel, "Target", true));
            this.dfTarget.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "SendEnabled", true));
            this.dfTarget.Location = new System.Drawing.Point(69, 23);
            this.dfTarget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dfTarget.Name = "dfTarget";
            this.dfTarget.Size = new System.Drawing.Size(132, 22);
            this.dfTarget.TabIndex = 1;
            // 
            // bindingSourceViewModel
            // 
            this.bindingSourceViewModel.DataSource = typeof(UI.GimmeAScreenshotPleaseUI.GimmeAScreenshotPleaseViewModel);
            // 
            // buttonListen
            // 
            this.buttonListen.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "SendEnabled", true));
            this.buttonListen.Location = new System.Drawing.Point(8, 23);
            this.buttonListen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(100, 28);
            this.buttonListen.TabIndex = 2;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // pbGet
            // 
            this.pbGet.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSourceViewModel, "SendEnabled", true));
            this.pbGet.Location = new System.Drawing.Point(211, 21);
            this.pbGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbGet.Name = "pbGet";
            this.pbGet.Size = new System.Drawing.Size(100, 28);
            this.pbGet.TabIndex = 3;
            this.pbGet.Text = "Get";
            this.pbGet.UseVisualStyleBackColor = true;
            this.pbGet.Click += new System.EventHandler(this.pbGet_Click);
            // 
            // pictureBoxScreenshot
            // 
            this.pictureBoxScreenshot.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bindingSourceViewModel, "Screenshot", true));
            this.pictureBoxScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxScreenshot.Location = new System.Drawing.Point(0, 71);
            this.pictureBoxScreenshot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
            this.pictureBoxScreenshot.Size = new System.Drawing.Size(1067, 483);
            this.pictureBoxScreenshot.TabIndex = 4;
            this.pictureBoxScreenshot.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.groupBoxServer);
            this.panelTop.Controls.Add(this.groupBoxClient);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1067, 71);
            this.panelTop.TabIndex = 5;
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.buttonListen);
            this.groupBoxServer.Location = new System.Drawing.Point(395, 4);
            this.groupBoxServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxServer.Size = new System.Drawing.Size(124, 60);
            this.groupBoxServer.TabIndex = 7;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Server";
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.dfTarget);
            this.groupBoxClient.Controls.Add(this.label1);
            this.groupBoxClient.Controls.Add(this.pbGet);
            this.groupBoxClient.Location = new System.Drawing.Point(4, 4);
            this.groupBoxClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxClient.Size = new System.Drawing.Size(325, 60);
            this.groupBoxClient.TabIndex = 6;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Client";
            // 
            // GimmeAScreenshotPleaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBoxScreenshot);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GimmeAScreenshotPleaseForm";
            this.Text = "GimmeAScreenshotPlease";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceViewModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dfTarget;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Button pbGet;
        private System.Windows.Forms.PictureBox pictureBoxScreenshot;
        private System.Windows.Forms.BindingSource bindingSourceViewModel;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.GroupBox groupBoxServer;
    }
}

