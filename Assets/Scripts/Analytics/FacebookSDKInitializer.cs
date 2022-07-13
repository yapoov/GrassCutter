using UnityEngine;

#if ANALYTICS_SDKS 
using Facebook.Unity;
#endif

#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif

public class FacebookSDKInitializer : MonoBehaviour
{
#if ANALYTICS_SDKS
    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }

#if UNITY_IOS
        Invoke(nameof(RegisterAppForNetworkAttribution), 1);
#endif
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private void RegisterAppForNetworkAttribution()
    {
        SkAdNetworkBinding.SkAdNetworkRegisterAppForNetworkAttribution();
    }
#endif
}