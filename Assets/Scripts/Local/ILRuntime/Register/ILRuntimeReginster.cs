using Framework.ILR.Service.Script;
using Framework.ILR.Service.Script.Adaptor;
using Framework.ILR.Service.Script.ValueTypeBinder;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.Utils;
using ILRuntime.Runtime;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;
using ILRuntime.CLR.TypeSystem;

namespace Game.Local.ILR.Reginster
{
    public class ILRuntimeReginster : IILRuntimeReginster
    {
        public unsafe void Reginster(AppDomain domain)
        {
            RegisterDelegateConvertor(domain);
            RegisterMethodDelegate(domain);
            RegisterValueTypeBinder(domain);
            RegisterCrossBindingAdaptor(domain);

            RegisterProtobuf(domain);

            //clr绑定 因为这个可以被删除所以为了删除之后不报错  就这样调用
            var t = Type.GetType("ILRuntime.Runtime.Generated.CLRBindings");
            if(t!= null)
            {
                t.GetMethod("Initialize")?.Invoke(null, new object[] { domain });
            }
        }

        #region DelegateConvertor
        /// <summary>
        /// 注册委托转换器
        /// </summary>
        /// <param name="domain"></param>
        static void RegisterDelegateConvertor(AppDomain domain)
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
        #endregion

        #region MethodDelegate
        /// <summary>
        /// 注册委托
        /// </summary>
        /// <param name="domain"></param>
        static void RegisterMethodDelegate(AppDomain domain)
        {
            domain.DelegateManager.RegisterMethodDelegate<Framework.Service.Network.INetworkPacket>();
            domain.DelegateManager.RegisterMethodDelegate<object>();
            domain.DelegateManager.RegisterMethodDelegate<object, object>();
            domain.DelegateManager.RegisterMethodDelegate<object, object, object>();
            domain.DelegateManager.RegisterMethodDelegate<object, object, object, object>();
            domain.DelegateManager.RegisterMethodDelegate<System.Int64>();
            domain.DelegateManager.RegisterMethodDelegate<UnityEngine.Object>();
            domain.DelegateManager.RegisterMethodDelegate<Boolean>();
            domain.DelegateManager.RegisterMethodDelegate<Single>();
            domain.DelegateManager.RegisterMethodDelegate<Boolean>();
            domain.DelegateManager.RegisterMethodDelegate<Boolean, GameObject>();
            domain.DelegateManager.RegisterMethodDelegate<Int32, Int32>();
            domain.DelegateManager.RegisterMethodDelegate<String>();
            domain.DelegateManager.RegisterMethodDelegate<ILTypeInstance>();
            domain.DelegateManager.RegisterMethodDelegate<GameObject>();
            domain.DelegateManager.RegisterMethodDelegate<Transform, UnityEngine.Object>();
            domain.DelegateManager.RegisterMethodDelegate<GameObject>();
            domain.DelegateManager.RegisterMethodDelegate<Int32>();
            domain.DelegateManager.RegisterMethodDelegate<GameObject, Action>();
        }
        #endregion

        #region ValueTypeBinder
        /// <summary>
        /// 注册值类型绑定
        /// </summary>
        /// <param name="domain"></param>
        static void RegisterValueTypeBinder(AppDomain domain)
        {
            domain.RegisterValueTypeBinder(typeof(Vector3), new Vector3Binder());
            domain.RegisterValueTypeBinder(typeof(Quaternion), new QuaternionBinder());
            domain.RegisterValueTypeBinder(typeof(Vector2), new Vector2Binder());
        }
        #endregion

        #region CrossBindingAdaptor
        /// <summary>
        /// 注册跨域继承适配器
        /// </summary>
        /// <param name="domain"></param>
        static void RegisterCrossBindingAdaptor(AppDomain domain)
        {
            //adaptor
            domain.RegisterCrossBindingAdaptor(new IAsyncStateMachineClassInheritanceAdaptor());
            domain.RegisterCrossBindingAdaptor(new ExceptionAdapter());
            domain.RegisterCrossBindingAdaptor(new IExtensibleAdapter());
            domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
        }
        #endregion

        #region Protobuf
        /// <summary>
        /// Protobuf相关的注册
        /// </summary>
        /// <param name="domain"></param>
        static unsafe void RegisterProtobuf(AppDomain domain)
        {
            //Protobuf 类型重定向
            PType.RegisterILRuntimeCLRRedirection(domain);

            //注册pb反序列化
            Type[] args;
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            Type pbSerializeType = typeof(Serializer);
            args = new[] { typeof(Type), typeof(Stream) };
            var pbDeserializeMethod = pbSerializeType.GetMethod("Deserialize", flag, null, args, null);
            domain.RegisterCLRMethodRedirection(pbDeserializeMethod, Deserialize_1);
            args = new[] { typeof(ILTypeInstance) };
            Dictionary<string, List<MethodInfo>> genericMethods = new Dictionary<string, List<MethodInfo>>();
            List<MethodInfo> lst = null;
            foreach (var m in pbSerializeType.GetMethods())
            {
                if (m.IsGenericMethodDefinition)
                {
                    if (!genericMethods.TryGetValue(m.Name, out lst))
                    {
                        lst = new List<MethodInfo>();
                        genericMethods[m.Name] = lst;
                    }
                    lst.Add(m);
                }
            }
            if (genericMethods.TryGetValue("Deserialize", out lst))
            {
                foreach (var m in lst)
                {
                    if (m.MatchGenericParameters(args, typeof(ILTypeInstance), typeof(Stream)))
                    {
                        var method = m.MakeGenericMethod(args);
                        domain.RegisterCLRMethodRedirection(method, Deserialize_2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// pb net 反序列化重定向
        /// </summary>
        /// <param name="__intp"></param>
        /// <param name="__esp"></param>
        /// <param name="__mStack"></param>
        /// <param name="__method"></param>
        /// <param name="isNewObj"></param>
        /// <returns></returns>
        private static unsafe StackObject* Deserialize_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            Stream source = (Stream)typeof(Stream).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            Type type = (Type)typeof(Type).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = Serializer.Deserialize(type, source);

            object obj_result_of_this_method = result_of_this_method;
            if (obj_result_of_this_method is CrossBindingAdaptorType)
            {
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance, true);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method, true);
        }

        /// <summary>
        /// pb net 反序列化重定向
        /// </summary>
        /// <param name="__intp"></param>
        /// <param name="__esp"></param>
        /// <param name="__mStack"></param>
        /// <param name="__method"></param>
        /// <param name="isNewObj"></param>
        /// <returns></returns>
        private static unsafe StackObject* Deserialize_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            Stream source = (Stream)typeof(Stream).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var genericArgument = __method.GenericArguments;
            var type = genericArgument[0];
            var realType = type is CLRType ? type.TypeForCLR : type.ReflectionType;
            var result_of_this_method = Serializer.Deserialize(realType, source);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }
        #endregion
    }
}

