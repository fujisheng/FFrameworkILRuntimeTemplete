using Framework.Service.FSM;
using ILHotfix;

namespace Game
{
    public class PatchInvoker : IPatchInvoker
    {
        public object Invoke(string typeName, string methodName, object instance, params object[] args)
        {
            return Modules.Script.InvokeMethod(typeName, methodName, instance, args);
        }
    }
    public class LoadModuleState : State<Launcher>
    {
        public override async void OnEnter(IFSM<Launcher> fsm)
        {
            Modules.Script.InvokeMethod("Game.Hotfix.Main", "Initialize", null, new object[] { Modules.Script });
            ChangeState<ConnectServer>(fsm);
        }

        public override void OnUpdate(IFSM<Launcher> fsm)
        {
            //scriptManager.OnUpdate();
            //scriptManager.OnLateUpdate();
        }
    }
}