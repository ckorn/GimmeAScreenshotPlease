using CrossCutting.DataClasses;
using Logic.Foundation.Screen.Contract;
using Logic.Foundation.Serialization.Contract;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logic.Foundation.ScreenSettings
{
    public class ScreenSettings : IScreenInformation
    {
        private readonly IDeserializer deserializer;

        public ScreenSettings(IDeserializer deserializer)
        {
            this.deserializer = deserializer;
        }

        public IReadOnlyList<ScreenInformation> GetScreenInformationList()
        {
            string json = File.ReadAllText("screenList.json");
            return this.deserializer.Deserialize<CrossCutting.DataClasses.ScreenSettings>(json).ScreenInformationList;
        }
    }
}
