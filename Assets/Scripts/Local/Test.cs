using Framework.ILR.Module.Script;
using Framework.ILR.Module.UI;
using Game;
using System;
using System.Collections;
using System.Collections.Generic;
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
