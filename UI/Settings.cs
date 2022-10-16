using BeatSaberMarkupLanguage.Attributes;
using OVRLipSync_Avatar_Extension.Configuration;
using UnityEngine;
using System.Collections.Generic;

namespace OVRLipSync_Avatar_Extension.UI
{
    internal class Settings : PersistentSingleton<Settings>
    {

        [UIValue("autosetup")]
        public bool AutoSetup
        {
            get => PluginConfig.Instance.AutoSetup;
            set => PluginConfig.Instance.AutoSetup = value;
        }

        [UIValue("micinput")]
        public string MicInput
        {
            get => PluginConfig.Instance.MicInput;
            set => PluginConfig.Instance.MicInput = value;
        }

        [UIValue("micoptions")]
        public List<object> MicOptions
        {
            get
            {
                var options = new List<object>();
                foreach (var device in Microphone.devices)
                {
                    options.Add(device);
                }
                return options;
            }
        }

    }
}
