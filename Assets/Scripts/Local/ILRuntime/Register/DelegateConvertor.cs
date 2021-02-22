using Framework.IL.Module.Script;
using System;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Game.Local.IL.Reginster
{
    public class DelegateConvertor : IDelegateConvertor
    {
        public void Convert(AppDomain domain)
        {
            domain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<float>>((action) =>
            {
                return new UnityEngine.Events.UnityAction<float>((a) =>
                {
                    ((Action<float>)action)(a);
                });
            });

            domain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((Action)act)();
                });
            });
        }
    }
}

