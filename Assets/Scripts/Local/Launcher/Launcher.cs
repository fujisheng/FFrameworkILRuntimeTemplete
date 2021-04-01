using FInject;
using Framework.ILR.Module.Script;
using Framework.Module;
using Framework.Module.Debugger;
using Framework.Module.FSM;
using Framework.Module.Resource;
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

            ModuleManager.SetInjectInfo(new ModuleDefaultInjectInfo());
            context = ModuleManager.InjectInfo.Context;

            context.Bind<IDebuggerManager>().AsInstance(ModuleManager.GetModule<IDebuggerManager>());
            context.Bind<IFSMManager>().AsInstance(ModuleManager.GetModule<IFSMManager>());

            context.Bind<IILRuntimeReginster>().As<ILRuntimeReginster>();
            IScriptManager scriptManager;
#if !ILRUNTIME
            scriptManager = EditorScriptManager.Instance;
            Debug.Log("<color=yellow>现在是通过直接加载dll调用的</color>");
#else
            scriptManager = ScriptManager.Instance;
            Debug.Log("<color=yellow>现在是直接通过ILRuntime调用的</color>");
#endif
            context.Bind<IScriptManager>().AsInstance(scriptManager);

            Injecter.Inject(typeof(Modules));
            await Modules.Script.Load("Code");
            var fsm = Modules.FSM.CreateFSM(this, new LoadModuleState());
            fsm.Start<LoadModuleState>();
            
        }
    }
}