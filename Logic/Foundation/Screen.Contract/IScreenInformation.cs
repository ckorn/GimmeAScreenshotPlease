using CrossCutting.DataClasses;
using System;
using System.Collections.Generic;

namespace Logic.Foundation.Screen.Contract
{
    public interface IScreenInformation
    {
        IReadOnlyList<ScreenInformation> GetScreenInformationList();
    }
}
