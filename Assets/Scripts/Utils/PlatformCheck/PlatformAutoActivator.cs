using UnityEngine;

public class PlatformAutoActivator : MonoBehaviour
{
    [Header("设置：仅在以下平台激活")]
    public bool activeOnAndroid = true;
    public bool activeOnIPhone = true;
    public bool activeOnWindows = false;

    void Awake()
    {
        // 默认先隐藏，然后根据宏定义判断是否开启
        bool shouldActive = false;

#if UNITY_ANDROID
        if (activeOnAndroid) shouldActive = true;
#elif UNITY_IOS
            if (activeOnIPhone) shouldActive = true;
#elif UNITY_STANDALONE_WIN
            if (activeOnWindows) shouldActive = true;
#endif

        // 设置物体的状态
        gameObject.SetActive(shouldActive);
    }
}