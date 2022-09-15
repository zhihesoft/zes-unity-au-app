using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Au
{
    public static class Utils
    {
        readonly static string[] webprefix = new string[] { "jar:", "http:", "https:" };

        public readonly static Encoding utf8WithoutBOM = new UTF8Encoding(false);

        public static bool IsWebFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            path = path.ToLower();

            foreach (var item in webprefix)
            {
                if (path.StartsWith(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static async Task WaitAsyncOperation(AsyncOperation op, Action<float> progress = null)
        {
            while (!op.isDone)
            {
                progress?.Invoke(op.progress);
                await Task.Yield();
            }
            progress?.Invoke(1);
        }

        public static async Task WaitUntil(Func<bool> condition)
        {
            while (!condition())
            {
                await Task.Yield();
            }
        }

        /// <summary>
        /// get unix timestamp (seconds from 1970-1-1)
        /// </summary>
        /// <returns></returns>
        public static long Timestamp()
        {
            var offset = new DateTimeOffset(DateTime.UtcNow);
            long stamp = offset.ToUnixTimeSeconds();
            return stamp;
        }

    }
}
