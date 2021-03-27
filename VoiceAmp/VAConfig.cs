using System.IO;
using BepInEx;
using BepInEx.Configuration;

namespace VoiceAmp
{
    internal class VAConfig
    {
        public ConfigEntry<float> AmpValue;

        public VAConfig()
        {
            var configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "VoiceAmp.cfg"), true);

            AmpValue = configFile.Bind("General", "Amplifier", 1f, "The amount to amplify your voice by");
        }
    }
}