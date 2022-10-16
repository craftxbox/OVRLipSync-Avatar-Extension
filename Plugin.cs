using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVRLipSync_Avatar_Extension.Configuration;
using BeatSaberMarkupLanguage.Settings;
using IPALogger = IPA.Logging.Logger;

namespace OVRLipSync_Avatar_Extension
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger logger, Config conf)
        {
            Instance = this;
            Log = logger;
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            Log.Debug("Config loaded");
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            new GameObject("OVRLipSync_Avatar_ExtensionController").AddComponent<OVRLipSync_Avatar_ExtensionController>();
            BSMLSettings.instance.AddSettingsMenu("OVRLipSync", "OVRLipSync_Avatar_Extension.UI.Settings.bsml", UI.Settings.instance);
        }
        
        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");

        }
    }
}
