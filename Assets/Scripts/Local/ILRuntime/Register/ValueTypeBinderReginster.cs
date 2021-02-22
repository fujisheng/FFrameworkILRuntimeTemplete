using Framework.IL.Module.Script;
using Framework.IL.ValueTypeBinder;
using ILRuntime.Runtime.Enviorment;
using UnityEngine;

namespace Game.Local.IL.Reginster
{
    public class ValueTypeBinderReginster : IValueTypeBinderReginster
    {
        public void Reginst(AppDomain appdomain)
        {
            appdomain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            appdomain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
            appdomain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
        }
    }
}