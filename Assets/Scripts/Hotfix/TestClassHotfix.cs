using ILHotfix;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass_Hotfix
{
    static TestClass Target;
    public static void SetTarget(TestClass target)
    {
        Target = target;
    }

    public static int Add( int b)
    {
        return Target.a + b;
    }

    public static void Print(int max)
    {
        for(int i = 1; i <= max; i++)
        {
            Debug.Log(i);
        }
    }
}