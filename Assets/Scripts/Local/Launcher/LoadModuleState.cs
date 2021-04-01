using Framework.ILR.Module.Script;
using Framework.Module;
using Framework.Module.Debugger;
using Framework.Module.FSM;

namespace Game.Launch
{
    public class LoadModuleState : State<Launcher>
    {
        IScriptManager scriptManager;
        public override async void OnEnter(IFSM<Launcher> fsm)
        {
            IDebuggerManager debugger = ModuleManager.Instance.GetModule<IDebuggerManager>();

#if !ILRUNTIME
            scriptManager = EditorScriptManager.Instance;
            debugger.LogY("现在是通过直接加载dll调用的");
#else
            scriptManager = ScriptManager.Instance;
            debugger.LogY("现在是直接通过ILRuntime调用的");
#endif
            fsm.Owner.injecter.Inject(scriptManager);
            await scriptManager.Load("Code");
            
            scriptManager.InvokeMethod("Game.Hotfix.Main", "Initialize", null, new object[] {scriptManager});
        }

        public override void OnUpdate(IFSM<Launcher> fsm)
        {
            //scriptManager.OnUpdate();
            //scriptManager.OnLateUpdate();
        }
    }
}