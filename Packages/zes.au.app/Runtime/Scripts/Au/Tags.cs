using Au.TS;
using System;
using UnityEngine;

namespace Au
{
    [JSWrap]
    public class Tags : MonoBehaviour
    {
        public Tag[] items;

        public GameObject Get(string name)
        {
            foreach (var tag in items)
            {
                if (tag.name == name)
                {
                    return tag.target;
                }
            }
            return null;
        }
    }

    [Serializable]
    public class Tag
    {
        public string name;
        public GameObject target;
    }
}
