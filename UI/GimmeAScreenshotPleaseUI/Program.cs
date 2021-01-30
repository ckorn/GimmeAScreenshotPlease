using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GimmeAScreenshotPleaseUI.Properties;

namespace UI.GimmeAScreenshotPleaseUI
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Settings.Default.UpgradePending)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradePending = false;
                Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GimmeAScreenshotPleaseForm());
        }
    }
}
