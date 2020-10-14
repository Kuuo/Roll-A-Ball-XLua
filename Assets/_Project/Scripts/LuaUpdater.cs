using System;
using UnityEngine;
using XLua;

[Hotfix]
public class LuaUpdater : MonoBehaviour
{
    private Action<float, float> _updateAction;
    private Action<float, float> _fixedUpdateAction;

    public void Init(LuaEnv env)
    {
        _updateAction = env.Global.Get<Action<float, float>>("update");
        _fixedUpdateAction = env.Global.Get<Action<float, float>>("fixedUpdate");
    }

    private void Update()
    {
        _updateAction?.Invoke(Time.deltaTime, Time.unscaledDeltaTime);
    }

    private void FixedUpdate()
    {
        _fixedUpdateAction?.Invoke(Time.fixedDeltaTime, Time.fixedUnscaledDeltaTime);
    }

    private void OnDestroy()
    {
        _updateAction = null;
        _fixedUpdateAction = null;
    }
}