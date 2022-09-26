using UnityEngine;

namespace Au.TS
{
    internal static class Logger
    {
        private static readonly string tag = "TS";

        public static bool enableDetailLogs = false;

        public static void Info(string message)
        {
            if (enableDetailLogs)
            {
                Debug.Log($"[{tag}] {message}");
            }
        }

        public static void Warn(string message)
        {
            Debug.LogWarning($"[{tag}] {message}");
        }

        public static void Error(string message)
        {
            Debug.LogError($"[{tag}] {message}");
        }

    }
}
