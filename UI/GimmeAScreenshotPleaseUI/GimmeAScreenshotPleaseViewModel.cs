using Logic.Business.ScreenshotClientWorkflow;
using Logic.Business.ScreenshotClientWorkflow.Contract;
using Logic.Business.ScreenshotServerWorkflow;
using Logic.Business.ScreenshotServerWorkflow.Contract;
using Logic.Foundation.Client;
using Logic.Foundation.Graphics;
using Logic.Foundation.Io;
using Logic.Foundation.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.GimmeAScreenshotPleaseUI
{
    public class GimmeAScreenshotPleaseViewModel : INotifyPropertyChanged
    {
        private readonly IClientWorkflow clientWorkflow;
        private readonly IServerWorkflow serverWorkflow;

        public string Target { get; set; }
        public bool SendEnabled { get => sendEnabled; set { if (SendEnabled != value) { sendEnabled = value; OnPropertyChanged(); } } }
        private bool sendEnabled = true;

        public Bitmap Screenshot { get => screenshot; set { if (Screenshot != value) { screenshot = value; OnPropertyChanged(); } } }
        private Bitmap screenshot = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private Control control;

        public GimmeAScreenshotPleaseViewModel()
        {
            this.clientWorkflow = new ClientWorkflow(new ScreenshotClient(new NamedPipeSender()));
            this.serverWorkflow = new ServerWorkflow(new ScreenshotServer(new Screenshot(), new NamedPipeReceiver(), new Resize()));
            this.serverWorkflow.ScreenshotSent += ServerWorkflow_ScreenshotSent;
        }

        public void SetControl(Control control) 
        {
            this.control = control;
        }

        private void ServerWorkflow_ScreenshotSent(object sender, System.Drawing.Bitmap e)
        {
            Task.Factory.StartNew(() => this.control.Invoke(new Action(() => this.Screenshot = e)));
        }

        public void StartServer() 
        {
            this.SendEnabled = false;
            Task.Factory.StartNew(() =>
            {
                this.serverWorkflow.Start();
            });
        }

        public void GetScreenShot() 
        {
            this.Screenshot = this.clientWorkflow.GetScreenshot(this.Target);
        }

        private void OnPropertyChanged([CallerMemberName] string propName = "") 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
