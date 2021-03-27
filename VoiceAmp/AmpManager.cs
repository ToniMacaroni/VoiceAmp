using System.Collections.Generic;
using Photon.Voice.Unity;
using Photon.Voice.Unity.UtilityScripts;
using UnityEngine;
using Zenject;

namespace VoiceAmp
{
    internal class AmpManager : IInitializable
    {
        private readonly VAConfig _config;
        private readonly List<MicAmplifier> _amps = new List<MicAmplifier>();

        public AmpManager(VAConfig config)
        {
            _config = config;
        }

        private void AddAmps()
        {
            var recorders = Resources.FindObjectsOfTypeAll<Recorder>();
            foreach (var recorder in recorders)
            {
                Debug.LogWarning($"Attaching to {recorder.name}");
                var amp = recorder.gameObject.AddComponent<MicAmplifier>();
                amp.AmplificationFactor = 1f;
                _amps.Add(amp);
            }
        }

        public void SetValue(float val)
        {
            val = Mathf.Clamp(val, 0.1f, 5f);

            foreach (var amp in _amps)
            {
                amp.AmplificationFactor = val;
            }

            _config.AmpValue.Value = val;
        }

        public float GetValue()
        {
            return _config.AmpValue.Value;
        }

        public void Initialize()
        {
            AddAmps();
            SetValue(_config.AmpValue.Value);
        }
    }
}