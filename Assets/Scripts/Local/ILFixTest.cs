using ILHotfix;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ILHotfix.Fix]
public static class TestClass
{
    public static int Add(int a, int b)
    {
        return a - b;
    }
}
