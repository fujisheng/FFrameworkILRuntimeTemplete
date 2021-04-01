using Framework.Module.FSM;

namespace Game
{
    public class LoadModuleState : State<Launcher>
    {
        public override async void OnEnter(IFSM<Launcher> fsm)
        {
            Modules.Script.InvokeMethod("Game.Hotfix.Main", "Initialize", null, new object[] {Modules.Script});
        }

        public override void OnUpdate(IFSM<Launcher> fsm)
        {
            //scriptManager.OnUpdate();
            //scriptManager.OnLateUpdate();
        }
    }
}