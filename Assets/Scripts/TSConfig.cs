using Au.TS;
using Puerts;
using System;
using System.Collections.Generic;

[Configure]
public class TSConfig
{
    [Binding]
    public static IEnumerable<Type> bindingTypes
    {
        get
        {
            return JSWrapper.Bind();
        }
    }
}
