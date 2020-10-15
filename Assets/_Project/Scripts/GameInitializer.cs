using UnityEngine;

public class GameInitializer : MonoBehaviour
{
#if UNITY_EDITOR
    public bool useAbLua;
#endif

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

#if UNITY_EDITOR
        xLuaManager.useAbLua = useAbLua;
#endif
        xLuaManager.Init();
    }
}