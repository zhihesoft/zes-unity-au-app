using Puerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Au.TS
{
    /// <summary>
    /// Get types of JSWrap attribute
    /// </summary>
    [Configure]
    public static class JSWrapper
    {
        [Binding]
        public static IEnumerable<Type> Bind
        {
            get
            {
                List<Type> typesList = new List<Type>();

                var wrapTypes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                from type in assembly.GetTypes()
                                where type.IsDefined(typeof(JSWrapAttribute), false)
                                select type;

                typesList.AddRange(wrapTypes);
                return typesList;
            }
        }

        [Filter]
        public static bool Filter(MemberInfo mb)
        {
            if (mb.IsDefined(typeof(JSIgnoreAttribute), false))
            {
                // Debug.Log($"{mb} is ignore");
                return true;
            }
            return false;
        }
    }
}
