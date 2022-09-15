using System.IO;

namespace Au
{
    /// <summary>
    /// Build No. of project
    /// </summary>
    public static class BuildNo
    {
        const string buildNoPath = ".buildno";

        /// <summary>
        /// Get current buildNo.
        /// </summary>
        /// <returns>BuildNo.</returns>
        public static int Get()
        {
            if (!File.Exists(buildNoPath))
            {
                return 0;
            }
            if (!int.TryParse(File.ReadAllText(buildNoPath), out int result))
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Increase build no.
        /// </summary>
        /// <returns>increased BuildNo.</returns>
        public static int Inc()
        {
            int result = Get();
            result += 1;
            using (var w = File.CreateText(buildNoPath))
            {
                w.Write(result);
            }
            return result;
        }
    }
}
