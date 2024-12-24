using Zenject;

namespace BlqzTweaks
{
    internal class AppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EditorButtonPatch>().AsSingle();
            Container.BindInterfacesTo<SaberClashPatch>().AsSingle();
            Container.BindInterfacesTo<WallClashPatch>().AsSingle();
            Container.BindInterfacesTo<DebrisPatch>().AsSingle();
            Container.BindInterfacesTo<CutParticlesPatch>().AsSingle();
            Container.BindInterfacesTo<BurnMarkAreaPatch>().AsSingle();
            Container.BindInterfacesTo<BurnMarkSparklesPatch>().AsSingle();
            Container.BindInterfacesTo<PlayerHeightPatch>().AsSingle();
            Container.BindInterfacesTo<PlayerSettingsPatch>().AsSingle();
        }
    }
}