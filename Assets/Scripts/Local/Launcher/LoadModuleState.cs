using Framework.Module;
using Framework.Module.Audio;
using Framework.Module.FSM;
using Framework.Module.Resource;
using Framework.Module.Script;
using Game.Local.IL.Reginster;
using UnityEngine;

namespace Game.Launch
{
    public class LoadModuleState : State<Launcher>
    {
        IScriptManager scriptManager;
        public override async void OnEnter(IFSM<Launcher> fsm)
        {
            ModuleManager.Instance.GetModule<IResourceManager>();
            ModuleManager.Instance.GetModule<IAudioManager>();

#if !ILRUNTIME
            scriptManager = EditorScriptManager.Instance;
            Debug.Log("现在是通过直接加载dll调用的");
#else
            scriptManager = ScriptManager.Instance;
            ScriptManager.Instance.SetReginster(new AdaptorReginster(), new CLRBinderReginster(), new ValueTypeBinderReginster(), new DelegateConvertor());
            Debug.Log("现在是直接通过ILRuntime调用的");
#endif
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