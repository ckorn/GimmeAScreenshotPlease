﻿using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Business.ScreenshotClientWorkflow.Contract
{
    public interface IClientWorkflow
    {
        Bitmap GetScreenshotPrimaryScreen(string target);
        Bitmap GetScreenshotForScreen(string target, ScreenInformation screenInformation);
        IReadOnlyList<ScreenInformation> GetScreenInformationList(string target);
    }
}
