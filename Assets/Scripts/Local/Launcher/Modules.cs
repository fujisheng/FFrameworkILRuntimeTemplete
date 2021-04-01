using FInject;
using Framework.ILR.Module.Script;
using Framework.Module.Debugger;
using Framework.Module.FSM;
using Framework.Module.Resource;

namespace Game
{
    public static class Modules
    {
        [Inject]
        public static IResourceManager Resource;

        [Inject]
        public static IDebuggerManager Debug;

        [Inject]
        public static IFSMManager FSM;

        [Inject]
        public static IScriptManager Script;
    }
}
