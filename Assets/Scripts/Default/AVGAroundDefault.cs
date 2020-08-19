using UnityEngine;

namespace Duo1J
{
    public class AVGAroundDefault : MonoBehaviour, Duo1JAround
    {
        public void After() { print("AVG End"); }

        public void Before() { print("AVG Start"); }
    }
}
