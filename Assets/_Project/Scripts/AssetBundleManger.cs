using System.IO;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public static class AssetBundleManger
{
    public static string assetBundleDirectory =>
        Path.Combine(Application.streamingAssetsPath, "Res_AB");

    private static string luaAssetBundlePath =>
        Path.Combine(assetBundleDirectory, "lua");

    private static string matAssetBundlePath =>
        Path.Combine(assetBundleDirectory, "mat");

    private static string objAssetBundlePath =>
        Path.Combine(assetBundleDirectory, "obj");

    private static AssetBundle _luaAb;
    private static AssetBundle _matAb;
    private static AssetBundle _gameObjectAb;

    public static void Init()
    {
        if (_luaAb == null)
        {
            _luaAb = AssetBundle.LoadFromFile(luaAssetBundlePath);
        }

        if (_matAb == null)
        {
            _matAb = AssetBundle.LoadFromFile(matAssetBundlePath);
        }

        if (_gameObjectAb == null)
        {
            _gameObjectAb = AssetBundle.LoadFromFile(objAssetBundlePath);
        }
    }

    public static byte[] LuaModuleLoader(string moduleName)
    {
        var asset = _luaAb.LoadAsset<TextAsset>($"{moduleName}.lua.txt");
        return asset.bytes;
    }

    public static Material LoadMaterial(string matName)
    {
        return _matAb.LoadAsset<Material>(matName);
    }

    public static GameObject LoadGameObject(string name)
    {
        return _gameObjectAb.LoadAsset<GameObject>(name);
    }
}