using System;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class TriggerBehaviour : MonoBehaviour
{
    public event Action<Collider> triggerEnter;
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEnter?.Invoke(other);
    }
}