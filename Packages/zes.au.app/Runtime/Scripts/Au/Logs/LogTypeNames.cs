using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Au.Logs
{
    internal static class LogTypeNames
    {
        public static string GetName(LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    return "ERROR";
                case LogType.Assert:
                    return "ASSERT";
                case LogType.Warning:
                    return "WARN";
                case LogType.Log:
                    return "INFO";
                case LogType.Exception:
                    return "EXCEPTION";
                default:
                    return type.ToString();
            }
        }
    }
}
