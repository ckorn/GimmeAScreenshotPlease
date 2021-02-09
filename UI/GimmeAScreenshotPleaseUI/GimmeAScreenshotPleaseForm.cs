using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.GimmeAScreenshotPleaseUI
{
    public partial class GimmeAScreenshotPleaseForm : Form
    {
        private readonly GimmeAScreenshotPleaseViewModel viewModel = new GimmeAScreenshotPleaseViewModel();
        public GimmeAScreenshotPleaseForm()
        {
            InitializeComponent();

            this.bindingSourceViewModel.DataSource = viewModel;
            this.viewModel.SetControl(this);
        }

        private void pbGet_Click(object sender, EventArgs e)
        {
            this.viewModel.GetScreenShot();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            this.viewModel.StartServer();
        }

        private void pbGetScreens_Click(object sender, EventArgs e)
        {
            this.viewModel.GetScreenList();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            // Show the form when the user double clicks on the notify icon.
            this.Show();

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            // Activate the form.
            this.Activate();
            notifyIcon.Visible = false;
        }

        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GimmeAScreenshotPleaseForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            ShowForm();
        }
    }
}
