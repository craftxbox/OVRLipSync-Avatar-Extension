using System;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;


[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace OVRLipSync_Avatar_Extension.Configuration
{
    public delegate void OnChangedHandler();
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        public static event OnChangedHandler OnChanged;

        public virtual bool AutoSetup { get; set; } = false;
        public virtual string MicInput { get; set; } = string.Empty; // Must be 'virtual' if you want BSIPA to detect a value change and save the config automatically.

        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            OnChanged();
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
        }
    }
}