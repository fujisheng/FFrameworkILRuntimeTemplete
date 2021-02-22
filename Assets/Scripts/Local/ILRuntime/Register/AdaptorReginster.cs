using Framework.IL.Adaptor;
using Framework.IL.Module.Script;
using ILRuntime.Runtime.Enviorment;

namespace Game.Local.IL.Reginster
{
    public class AdaptorReginster : IAdpaterReginster
    {
        public void Reginst(AppDomain domain)
        {
            domain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());
        }
    }
}

