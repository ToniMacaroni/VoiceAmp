using System;
using ComputerInterface.Interfaces;

namespace VoiceAmp
{
    internal class VoiceAmpEntry : IComputerModEntry
    {
        public string EntryName => "Voice Amp";
        public Type EntryViewType => typeof(VoiceAmpView);
    }
}