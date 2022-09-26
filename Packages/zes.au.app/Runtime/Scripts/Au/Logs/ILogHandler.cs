using UnityEngine;

namespace Au.Logs
{
    public interface ILogHandler
    {
        void Start();
        void Stop();
        void WriteLine(LogType type, string message);
    }
}
