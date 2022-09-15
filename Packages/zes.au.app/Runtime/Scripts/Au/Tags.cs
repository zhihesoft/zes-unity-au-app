using UnityEngine;

namespace Au
{
    public class Tags : MonoBehaviour
    {
        public TagData[] tags;

        public GameObject Get(string name)
        {
            foreach (var tag in tags)
            {
                if (tag.tagName == name)
                {
                    return tag.tagGo;
                }
            }
            return null;
        }
    }
}
