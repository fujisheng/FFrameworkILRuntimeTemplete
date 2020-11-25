using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {

        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector3> s_UnityEngine_Vector3_Binding_Binder = null;
        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Quaternion> s_UnityEngine_Quaternion_Binding_Binder = null;
        internal static ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector2> s_UnityEngine_Vector2_Binding_Binder = null;

        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            Framework_Utility_StringUtility_Binding.Register(app);
            System_Type_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            System_Activator_Binding.Register(app);
            System_String_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            System_Object_Binding.Register(app);
            System_Reflection_PropertyInfo_Binding.Register(app);
            System_Collections_Generic_List_1_Button_Binding.Register(app);
            System_Collections_Generic_List_1_Button_Binding_Enumerator_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            UnityEngine_Events_UnityEventBase_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Queue_1_ILTypeInstance_Binding.Register(app);
            Cysharp_Threading_Tasks_CompilerServices_AsyncUniTaskMethodBuilder_Binding.Register(app);
            Cysharp_Threading_Tasks_UniTask_Binding.Register(app);
            Cysharp_Threading_Tasks_UniTask_Binding_Awaiter_Binding.Register(app);
            Cysharp_Threading_Tasks_CompilerServices_AsyncUniTaskMethodBuilder_1_ILTypeInstance_Binding.Register(app);
            System_Exception_Binding.Register(app);
            System_Collections_Generic_List_1_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Reflection_FieldInfo_Binding.Register(app);
            System_ValueTuple_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_List_1_ValueTuple_2_String_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Reflection_MethodInfo_Binding.Register(app);
            System_Reflection_MethodBase_Binding.Register(app);
            Framework_Module_Resource_IResourceLoader_Binding.Register(app);
            Cysharp_Threading_Tasks_UniTask_1_GameObject_Binding.Register(app);
            Cysharp_Threading_Tasks_UniTask_1_GameObject_Binding_Awaiter_Binding.Register(app);
            System_Reflection_Assembly_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_ILTypeInstance_Binding.Register(app);
            Cysharp_Threading_Tasks_CompilerServices_AsyncUniTaskMethodBuilder_1_GameObject_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_GameObject_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Stack_1_ILTypeInstance_Binding.Register(app);
            System_Runtime_CompilerServices_AsyncVoidMethodBuilder_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_List_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding_ValueCollection_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding_ValueCollection_Binding_Enumerator_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Vector3));
            s_UnityEngine_Vector3_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector3>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Quaternion));
            s_UnityEngine_Quaternion_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Quaternion>;
            __clrType = (ILRuntime.CLR.TypeSystem.CLRType)app.GetType (typeof(UnityEngine.Vector2));
            s_UnityEngine_Vector2_Binding_Binder = __clrType.ValueTypeBinder as ILRuntime.Runtime.Enviorment.ValueTypeBinder<UnityEngine.Vector2>;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            s_UnityEngine_Vector3_Binding_Binder = null;
            s_UnityEngine_Quaternion_Binding_Binder = null;
            s_UnityEngine_Vector2_Binding_Binder = null;
        }
    }
}
