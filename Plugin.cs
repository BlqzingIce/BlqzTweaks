using SiraUtil.Zenject;
using IPA;
using IPALogger = IPA.Logging.Logger;

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
            
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            
        }
    }
}