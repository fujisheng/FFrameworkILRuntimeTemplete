using FInject;
using Framework.ILR.Service.Script;
using Framework.Service;
using Framework.Service.Debug;
using Framework.Service.FSM;
using Framework.Service.Network;
using Framework.Service.Resource;
using Game.Local.ILR.Reginster;
using UnityEngine;

namespace Game
{
    public class Launcher : MonoBehaviour
    {
        public Context context { get; private set; }

        
        private async void Awake()
        {
            DontDestroyOnLoad(gameObject);

            Services.SetInjectInfo(new ServicesDefaultInjectInfo());
            context = Services.InjectInfo.Context;

            context.Bind<IDebugService>().AsInstance(Services.Get<IDebugService>());
            context.Bind<IFSMService>().AsInstance(Services.Get<IFSMService>());
            context.Bind<INetworkService>().AsInstance(Services.Get<INetworkService>());
            context.Bind<INetworkSerializeHelper>().AsInstance(new ProtobufSerializer());

            context.Bind<IILRuntimeReginster>().As<ILRuntimeReginster>();
            IScriptService scriptManager;
#if !ILRUNTIME
            scriptManager = MonoScriptService.Instance;
            Debug.Log("<color=yellow>现在是直接加载dll调用的</color>");
#else
            scriptManager = ILRuntimeScriptService.Instance;
            Debug.Log("<color=yellow>现在是通过ILRuntime调用的</color>");
#endif
            context.Bind<IScriptService>().AsInstance(scriptManager);
            
            Injecter.Inject(typeof(Modules));
            await Modules.Script.Load("Code");
            var fsm = Modules.FSM.CreateFSM(this, new LoadModuleState(), new ConnectServer());
            fsm.Start<LoadModuleState>();
        }
    }
}