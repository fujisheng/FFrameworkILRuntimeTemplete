using ILHotfix;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ILHotfix.Fix]
public class TestClass
{
    public int a = 0;
    public int Add(int b)
    {
        return a - b;
    }

    public void Print(int max)
    {
        for(int i = 0; i < max; i++)
        {
            Debug.Log(i);
        }
    }
}
