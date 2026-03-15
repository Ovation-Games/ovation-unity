using UnityEngine;

namespace Ovation.Utils
{
    internal static class OvationLogger
    {
        private static bool _enabled;

        internal static void SetEnabled(bool enabled)
        {
            _enabled = enabled;
        }

        internal static void Log(string message)
        {
            if (_enabled)
                Debug.Log($"[Ovation] {message}");
        }

        internal static void Warning(string message)
        {
            if (_enabled)
                Debug.LogWarning($"[Ovation] WARNING: {message}");
        }

        internal static void Error(string message)
        {
            // Errors always log regardless of debug setting
            Debug.LogError($"[Ovation] ERROR: {message}");
        }
    }
}
