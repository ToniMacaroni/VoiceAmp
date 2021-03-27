using ComputerInterface.Interfaces;
using Zenject;

namespace VoiceAmp
{
    internal class MainInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<VAConfig>().AsSingle();
            Container.BindInterfacesAndSelfTo<AmpManager>().AsSingle();
            Container.Bind<IComputerModEntry>().To<VoiceAmpEntry>().AsSingle();
        }
    }
}