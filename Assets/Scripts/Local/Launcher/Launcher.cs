using FInject;
using Framework.Module;
using Framework.Module.Debugger;
using Framework.Module.FSM;
using Framework.Module.Resource;
using UnityEngine;

namespace Game.Launch
{
    public class Launcher : MonoBehaviour
    {
        public Context context { get; private set; }
        public Injecter injecter { get; private set; }
        private void Awake()
        {
            context = new Context();
            injecter = new Injecter(context);
            
            ModuleManager.Instance.Injecter = injecter;

            var resourceManager = ModuleManager.Instance.GetModule<IResourceManager>();

            context.Bind<IResourceManager>().ToInstance(resourceManager);
            context.Bind<IResourceLoader>().To<ResourceLoader>();
            context.Bind<IDebugger>().To<UnityDebugger>();

            var fsmManager = ModuleManager.Instance.GetModule<IFSMManager>();
            var fsm = fsmManager.CreateFSM<Launcher>(this, new LoadModuleState());
            fsm.Start<LoadModuleState>();
            DontDestroyOnLoad(gameObject);
        }
    }
}