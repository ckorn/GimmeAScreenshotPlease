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

        private void buttonWriteConfig_Click(object sender, EventArgs e)
        {
            this.viewModel.WriteScreenSettings();
        }
    }
}
