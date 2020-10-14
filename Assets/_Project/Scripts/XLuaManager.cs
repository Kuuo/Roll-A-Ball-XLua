using System;
using UnityEngine;
using XLua;

public class XLuaManager : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        InitEnv();

        InitUpdater();
    }

    private void InitEnv()
    {
        _env = new LuaEnv();

        _env.DoString("require 'main'");
    }

    private void InitUpdater()
    {
        if (!gameObject.TryGetComponent(out LuaUpdater updater))
        {
            updater = gameObject.AddComponent<LuaUpdater>();
        }

        updater.Init(_env);
    }

    private void Update()
    {
        _env?.Tick();
    }
}