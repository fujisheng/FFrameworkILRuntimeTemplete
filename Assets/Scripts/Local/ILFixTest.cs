using ILHotfix;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ILHotfix.Hotfix]
public class TestClass
{
    public int Add(int a, int b)
    {
        return a - b;
    }
}
