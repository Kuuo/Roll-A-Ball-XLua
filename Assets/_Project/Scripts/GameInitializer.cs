using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        AssetBundleManger.Init();

        if (!gameObject.TryGetComponent(out XLuaManager xLuaManager))
        {
            xLuaManager = gameObject.AddComponent<XLuaManager>();
        }
        
        xLuaManager.Init();
    }
}