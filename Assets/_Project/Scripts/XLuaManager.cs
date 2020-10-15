using System.IO;
using System.Text;
using UnityEngine;
using XLua;

public class XLuaManager : MonoBehaviour
{
#if UNITY_EDITOR
    public bool useAbLua { get; set; }
#endif
    
    private LuaEnv _env;

    public void Init()
    {
        InitEnv();

        _env?.DoString("require 'main'", "main");

        InitUpdater();
    }

    private void InitEnv()
    {
        _env = new LuaEnv();
        _env.AddLoader(LuaLoader);
    }

    private byte[] LuaLoader(ref string filepath)
    {
#if UNITY_EDITOR
        return useAbLua
            ? AssetBundleManger.LuaModuleLoader(filepath)
            : RawLuaLoader(filepath);
#else
        return AssetBundleManger.LuaModuleLoader(filepath);
#endif
    }

    private static byte[] RawLuaLoader(string luaModuleName)
    {
        var path = Path.Combine(Application.dataPath, "LuaData", $"{luaModuleName}.lua.txt");
        var content = File.ReadAllText(path, Encoding.UTF8);
        return Encoding.ASCII.GetBytes(content);
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