using SiraUtil.Zenject;
using IPA;
using IPALogger = IPA.Logging.Logger;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlqzTweaks
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        private IPALogger _log;
        private Zenjector _zenjector;

        [Init]
        public void Init(IPALogger logger, Zenjector zenjector)
        {
            _log = logger;
            _zenjector = zenjector;

            zenjector.UseMetadataBinder<Plugin>();
            zenjector.UseLogger(logger);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            _zenjector.Install<AppInstaller>(Location.App);
            SetGlobalParticlesEnabled(false);
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
            SetGlobalParticlesEnabled(true);
        }
        
        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1) {
                SetGlobalParticlesEnabled(false);
        }
        
        private void SetGlobalParticlesEnabled(bool enable)
        {
            foreach(var x in Resources.FindObjectsOfTypeAll<ParticleSystem>())
                if(x.name == "DustPS") x.gameObject.SetActive(enable);
        }
    }
}