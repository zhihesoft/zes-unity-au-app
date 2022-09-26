using Puerts;
using System.Collections.Generic;
using UnityEngine;

[Configure]
public class Test
{
    [Binding]
    public static IEnumerable<System.Type> bindings
    {
        get
        {
            return new System.Type[] {
                typeof(GameObject),
                typeof(UnityEngine.UI.Image),
            };
        }
    }
}
