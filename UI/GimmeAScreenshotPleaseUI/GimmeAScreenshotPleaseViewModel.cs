﻿using CrossCutting.DataClasses;
using Logic.Business.ScreenshotClientWorkflow;
using Logic.Business.ScreenshotClientWorkflow.Contract;
using Logic.Business.ScreenshotServerWorkflow;
using Logic.Business.ScreenshotServerWorkflow.Contract;
using Logic.Domain.Client;
using Logic.Foundation.Encodings;
using Logic.Foundation.Graphics;
using Logic.Foundation.IoHttp;
using Logic.Foundation.Serialization;
using Logic.Domain.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GimmeAScreenshotPleaseUI.Properties;

namespace UI.GimmeAScreenshotPleaseUI
{
    public class GimmeAScreenshotPleaseViewModel : INotifyPropertyChanged
    {
        private readonly IClientWorkflow clientWorkflow;
        private readonly IServerWorkflow serverWorkflow;

        public string Target { get => target; set { if (Target != value) { target = value; OnPropertyChanged(); } } }

        private string target = "";
        public bool SendEnabled { get => sendEnabled; set { if (SendEnabled != value) { sendEnabled = value; OnPropertyChanged(); } } }
        private bool sendEnabled = true;

        public Bitmap Screenshot { get => screenshot; set { if (Screenshot != value) { screenshot = value; OnPropertyChanged(); } } }
        private Bitmap screenshot = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<ScreenInformation> ScreenInformationList { get; set; } = new BindingList<ScreenInformation>();
        public ScreenInformation ScreenInformationEditValue { get; set; }

        private Control control;

        public GimmeAScreenshotPleaseViewModel()
        {
            this.clientWorkflow = new ClientWorkflow(new ScreenshotClient(new HttpSender(),
                new BinaryDecoder(), new JsonSerializer(), new JsonDeserializer()));
            this.serverWorkflow = new ServerWorkflow(new ScreenshotServer(new Screenshot(), new HttpReceiver(new HttpServer()), new Resize(),
                new BinaryEncoder(), new JsonSerializer(), new JsonDeserializer()));
            this.serverWorkflow.ScreenshotSent += ServerWorkflow_ScreenshotSent;

            this.Target = Properties.Settings.Default.Target;
            this.PropertyChanged += GimmeAScreenshotPleaseViewModel_PropertyChanged;
        }

        private void GimmeAScreenshotPleaseViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Target))
            {
                Settings.Default.Target = this.Target;
                Settings.Default.Save();
            }
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
                this.serverWorkflow.StartSendPrimaryScreen();
            });
            Task.Factory.StartNew(() =>
            {
                this.serverWorkflow.StartSendScreen();
            });
            Task.Factory.StartNew(() =>
            {
                this.serverWorkflow.StartSendScreenList();
            });
        }

        public void GetScreenShot()
        {
            this.SendEnabled = false;
            Task.Factory.StartNew(() =>
            {
                if ((ScreenInformationEditValue?.Index ?? -1) >= 0)
                {
                    return Task.Run(async () => await this.clientWorkflow.GetScreenshotForScreenAsync(this.Target, this.ScreenInformationEditValue)).Result;
                }
                else
                {
                    return Task.Run(async () => await this.clientWorkflow.GetScreenshotPrimaryScreenAsync(this.Target, null)).Result;
                }
            }).ContinueWith(task =>
             {
                 this.SendEnabled = true;
                 if (task.Exception == null)
                 {
                     this.Screenshot = task.Result;
                 }
                 else
                 {
                     MessageBox.Show(task.Exception.Message);
                 }
             }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        public void GetScreenList()
        {
            IReadOnlyList<ScreenInformation> screenInformationList = Task.Run(async () => await this.clientWorkflow.GetScreenInformationListAsync(this.Target)).Result;
            this.ScreenInformationList.Clear();
            this.ScreenInformationList.Add(new ScreenInformation(-1, string.Empty, 0, 0, 0, 0));
            foreach (ScreenInformation screenInformation in screenInformationList)
            {
                this.ScreenInformationList.Add(screenInformation);
            }
            this.ScreenInformationEditValue = this.ScreenInformationList.First();
        }

        private void OnPropertyChanged([CallerMemberName] string propName = "") 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
