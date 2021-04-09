using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass_Hotfix
{
    static TestClass origin;
    public static void SetOrigin(TestClass origin)
    {
        TestClass_Hotfix.origin = origin;
    }
    public static int Add(int a, int b)
    {
        return a + b;
    }
}