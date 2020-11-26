using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class System_ValueTuple_2_Object_MethodInfo_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(System.ValueTuple<System.Object, System.Reflection.MethodInfo>);

            field = type.GetField("Item2", flag);
            app.RegisterCLRFieldGetter(field, get_Item2_0);
            app.RegisterCLRFieldSetter(field, set_Item2_0);
            app.RegisterCLRFieldBinding(field, CopyToStack_Item2_0, AssignFromStack_Item2_0);
            field = type.GetField("Item1", flag);
            app.RegisterCLRFieldGetter(field, get_Item1_1);
            app.RegisterCLRFieldSetter(field, set_Item1_1);
            app.RegisterCLRFieldBinding(field, CopyToStack_Item1_1, AssignFromStack_Item1_1);

            app.RegisterCLRCreateDefaultInstance(type, () => new System.ValueTuple<System.Object, System.Reflection.MethodInfo>());

            args = new Type[]{typeof(System.Object), typeof(System.Reflection.MethodInfo)};
            method = type.GetConstructor(flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Ctor_0);

        }

        static void WriteBackInstance(ILRuntime.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref System.ValueTuple<System.Object, System.Reflection.MethodInfo> instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as System.ValueTuple<System.Object, System.Reflection.MethodInfo>[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_Item2_0(ref object o)
        {
            return ((System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o).Item2;
        }

        static StackObject* CopyToStack_Item2_0(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o).Item2;
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static void set_Item2_0(ref object o, object v)
        {
            System.ValueTuple<System.Object, System.Reflection.MethodInfo> ins =(System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o;
            ins.Item2 = (System.Reflection.MethodInfo)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Item2_0(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Reflection.MethodInfo @Item2 = (System.Reflection.MethodInfo)typeof(System.Reflection.MethodInfo).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            System.ValueTuple<System.Object, System.Reflection.MethodInfo> ins =(System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o;
            ins.Item2 = @Item2;
            o = ins;
            return ptr_of_this_method;
        }

        static object get_Item1_1(ref object o)
        {
            return ((System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o).Item1;
        }

        static StackObject* CopyToStack_Item1_1(ref object o, ILIntepreter __intp, StackObject* __ret, IList<object> __mStack)
        {
            var result_of_this_method = ((System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o).Item1;
            object obj_result_of_this_method = result_of_this_method;
            if(obj_result_of_this_method is CrossBindingAdaptorType)
            {    
                return ILIntepreter.PushObject(__ret, __mStack, ((CrossBindingAdaptorType)obj_result_of_this_method).ILInstance, true);
            }
            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method, true);
        }

        static void set_Item1_1(ref object o, object v)
        {
            System.ValueTuple<System.Object, System.Reflection.MethodInfo> ins =(System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o;
            ins.Item1 = (System.Object)v;
            o = ins;
        }

        static StackObject* AssignFromStack_Item1_1(ref object o, ILIntepreter __intp, StackObject* ptr_of_this_method, IList<object> __mStack)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            System.Object @Item1 = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            System.ValueTuple<System.Object, System.Reflection.MethodInfo> ins =(System.ValueTuple<System.Object, System.Reflection.MethodInfo>)o;
            ins.Item1 = @Item1;
            o = ins;
            return ptr_of_this_method;
        }


        static StackObject* Ctor_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);
            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Reflection.MethodInfo @item2 = (System.Reflection.MethodInfo)typeof(System.Reflection.MethodInfo).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Object @item1 = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = new System.ValueTuple<System.Object, System.Reflection.MethodInfo>(@item1, @item2);

            if(!isNewObj)
            {
                __ret--;
                WriteBackInstance(__domain, __ret, __mStack, ref result_of_this_method);
                return __ret;
            }

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


    }
}
