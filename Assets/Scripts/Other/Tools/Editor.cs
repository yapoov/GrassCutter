using UnityEngine;
using UnityEditor;

public static partial class A {

    ///<summary>asset-с обект унших</summary>
    public static T LoadAsset<T>(string path) {
#if UNITY_EDITOR
        return (T)(object)AssetDatabase.LoadAssetAtPath(path, typeof(T));
#else
        return default(T);
#endif
    }

    ///<summary>тоглоом эхлэхэд GameView scale-г тааруулна</summary>
    public static void SetGameViewScale() {
#if UNITY_EDITOR
        System.Reflection.Assembly assembly = typeof(EditorWindow).Assembly;
        System.Type type = assembly.GetType("UnityEditor.GameView");
        EditorWindow v = EditorWindow.GetWindow(type);
        var defScaleField = type.GetField("m_defaultScale", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        float defaultScale = 0.1f;
        var areaField = type.GetField("m_ZoomArea", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        var areaObj = areaField.GetValue(v);
        var scaleField = areaObj.GetType().GetField("m_Scale", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        scaleField.SetValue(areaObj, new Vector2(defaultScale, defaultScale));
#endif
    }

    ///<summary>нээлттэй scene-г хадгална</summary>
    public static void SaveOpenScenes() {
#if UNITY_EDITOR
        UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
#endif
    }

    ///<summary>PlayerSettings-г бөглөнө</summary>
    public static void PlayerSettingsChange() {
#if UNITY_EDITOR
        PlayerSettings.companyName = GC.companyName;
        PlayerSettings.productName = GC.productName;
        int lastDotIdx = GC.companyWebSite.LastIndexOf('.');
        PlayerSettings.applicationIdentifier =
            GC.companyWebSite.SubStr(lastDotIdx + 1, GC.companyWebSite.Length - lastDotIdx - 1) + "." +
            GC.companyWebSite.SubStr(0, lastDotIdx) + "." +
            Rgx.Replace(GC.productName, "\\s+", "").ToLower();
        PlayerSettings.bundleVersion = GC.version;
        Texture2D[] icons = new Texture2D[] { GC.icon };
        PlayerSettings.SetIconsForTargetGroup(BuildTargetGroup.Unknown, icons);
        PlayerSettings.SplashScreen.show = false;
        PlayerSettings.SplashScreen.logos = null;
        Texture2D iphone = GC.iPhoneLaunchScreen, ipad = GC.iPadLaunchScreen;
        PlayerSettings.iOS.SetiPhoneLaunchScreenType(iOSLaunchScreenType.ImageAndBackgroundRelative);
        PlayerSettings.iOS.SetLaunchScreenImage(iphone, iOSLaunchScreenImageType.iPhonePortraitImage);
        PlayerSettings.iOS.SetiPadLaunchScreenType(iOSLaunchScreenType.ImageAndBackgroundRelative);
        PlayerSettings.iOS.SetLaunchScreenImage(ipad, iOSLaunchScreenImageType.iPadImage);
        PlayerSettings.SplashScreen.show = true;
        if (iphone)
            PlayerSettings.SplashScreen.background = TexSpr(iphone);
#endif
    }
}