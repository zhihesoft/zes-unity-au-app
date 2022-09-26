using Au.Logs;
using System.Collections.Generic;
using UnityEngine;

namespace Au
{
    public class Log
    {
        private static Dictionary<string, Log> loggers = new Dictionary<string, Log>();
        private static List<Logs.ILogHandler> handlers = new List<Logs.ILogHandler>();

        private static void AddHandler(Logs.ILogHandler handler)
        {
            if (handlers.Count <= 0)
            {
                Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
            }
            handler.Start();
            handlers.Add(handler);
        }

        public static void AddFile(string name, int maxSize, int maxCount)
        {
            var handler = new FileLog(name, maxSize, maxCount);
            AddHandler(handler);
        }

        public static void Stop()
        {
            if (handlers.Count > 0)
            {
                Application.logMessageReceivedThreaded -= Application_logMessageReceivedThreaded;
                foreach (var handler in handlers)
                {
                    handler.Stop();
                }
                handlers.Clear();
            }
        }

        private static void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
        {
            foreach (var handler in handlers)
            {
                handler.WriteLine(type, condition);
            }
        }

        /// <summary>
        /// Get a Logger from type
        /// </summary>
        /// <typeparam name="T">Class Type</typeparam>
        /// <returns>Logger</returns>
        public static Log GetLogger<T>()
        {
            return GetLogger(typeof(T).FullName);
        }

        /// <summary>
        /// Get a Logger from name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Logger</returns>
        public static Log GetLogger(string name)
        {
            if (loggers.TryGetValue(name, out Log logger))
            {
                return logger;
            }
            logger = new Log(name);
            loggers.Add(name, logger);
            return logger;
        }

        private Log(string name)
        {
            this.name = name;
        }

        private string name;

        public void Info(object message)
        {
            Debug.Log($"[{name}] {message}");
        }

        public void Warn(object message)
        {
            Debug.LogWarning($"[{name}] {message}");
        }

        public void Error(object message)
        {
            Debug.LogError($"[{name}] {message}");
        }
    }
}
