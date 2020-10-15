using System.IO;
using UnityEditor;

public static class BuildTool
{
    [MenuItem("Tools/Build AssetBundles")]
    private static void BuildAllAssetBundles()
    {
        var assetBundleDirectory = AssetBundleManger.assetBundleDirectory;
        
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
            BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows);
    }
}