using Framework.ILR.Module.Script;
using Framework.ILR.Module.Script.Adaptor;
using Framework.ILR.Module.Script.ValueTypeBinder;
using System;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

namespace Game.Local.ILR.Reginster
{
    public class ILRuntimeReginster : IILRuntimeReginster
    {
        public void Reginster(AppDomain domain)
        {
            //Delegate
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

            //值类型
            domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
            domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());

            //clr
            ILRuntime.Runtime.Generated.CLRBindings.Initialize(domain);

            //adaptor
            domain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());
            //domain.RegisterCrossBindingAdaptor(new AttributeAdaptor());
            domain.RegisterCrossBindingAdaptor(new ViewAdapter());
            domain.RegisterCrossBindingAdaptor(new ViewModelAdapter());
        }
    }
}

