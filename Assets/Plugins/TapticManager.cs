using System.Runtime.InteropServices;

namespace TapticPlugin {
    public enum Notification { Success, Warning, Error }
    public enum Impact { Light, Medium, Heavy }
    public static class TapticManager {
        public static void Notification (Notification feedback) { _unityTapticNotification ((int) feedback); }
        public static void Impact (Impact feedback) { _unityTapticImpact ((int) feedback); }
        public static void Selection () { _unityTapticSelection (); }
        public static bool IsSupport () { return _unityTapticIsSupport (); }
        #region DllImport
#if UNITY_IPHONE && !UNITY_EDITOR
        [DllImport ("__Internal")]
        private static extern void _unityTapticNotification (int type);
        [DllImport ("__Internal")]
        private static extern void _unityTapticSelection ();
        [DllImport ("__Internal")]
        private static extern void _unityTapticImpact (int style);
        [DllImport ("__Internal")]
        private static extern bool _unityTapticIsSupport ();
#else
        private static void _unityTapticNotification (int type) { }
        private static void _unityTapticSelection () { }
        private static void _unityTapticImpact (int style) { }
        private static bool _unityTapticIsSupport () { return false; }
#endif
        #endregion
    }
}