using Framework.ILR.Module.Script;
using System;
using UnityEngine;

public static class Test
{
    public static void ShowType(Type type)
    {
        Debug.Log($"local type=>{type}");
        
        var view = ScriptManager.Instance.appdomain.Instantiate(type.FullName);
        Debug.Log(view);
    }

    public static void ShowType<T>()
    {
        Debug.Log($"local type=>{typeof(T)}");
    }
}
