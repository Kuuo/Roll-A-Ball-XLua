using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public static class MyXLuaConfig
{
    [CSharpCallLua]
    private static List<Type> csCallLuaTypes =>
        new List<Type>
        {
            typeof(Action<float, float>),
            
            // typeof(Action<Collider>)
        };
}