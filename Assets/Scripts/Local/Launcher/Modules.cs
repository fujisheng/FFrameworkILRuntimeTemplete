using FInject;
using Framework.ILR.Service.Script;
using Framework.Service.Debug;
using Framework.Service.FSM;
using Framework.Service.Network;
using Framework.Service.Resource;

namespace Game
{
    public static class Modules
    {
        [Inject]
        public static IResourceService Resource;

        [Inject]
        public static IDebugService Debug;

        [Inject]
        public static IFSMService FSM;

        [Inject]
        public static IScriptService Script;

        [Inject]
        public static INetworkService Network;
    }
}
