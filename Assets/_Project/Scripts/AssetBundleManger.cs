using System.IO;
using UnityEngine;
using XLua;

public static class AssetBundleManger
{
    public static string assetBundleDirectory =>
        Path.Combine(Application.streamingAssetsPath, "Res_AB");

    private static string luaAssetBundlePath =>
        Path.Combine(assetBundleDirectory, "lua");
    
    private static string matAssetBundlePath =>
        Path.Combine(assetBundleDirectory, "mat");

    private static AssetBundle _luaAb;
    private static AssetBundle _matAb;

    public static void Init()
    {
        _luaAb = AssetBundle.LoadFromFile(luaAssetBundlePath);
        _matAb = AssetBundle.LoadFromFile(matAssetBundlePath);
    }
    
    public static byte[] LuaModuleLoader(ref string moduleName)
    {
        var asset = _luaAb.LoadAsset<TextAsset>($"{moduleName}.lua.txt");
        return asset.bytes;
    }

    public static Material LoadMaterial(string matName)
    {
        return _matAb.LoadAsset<Material>(matName);
    }
}