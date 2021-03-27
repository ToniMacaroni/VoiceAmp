using System;
using BepInEx;
using Bepinject;

namespace VoiceAmp
{
    [BepInDependency("tonimacaroni.computerinterface", "1.4.0")]
    [BepInPlugin(PLUGIN_ID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_ID = "tonimacaroni.voiceamp";
        public const string PLUGIN_NAME = "Voice Amp";
        public const string PLUGIN_VERSION = "1.0.0";

        private void Awake()
        {
            Zenjector.Install<MainInstaller>().OnProject();
        }
    }
}
