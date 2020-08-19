using UnityEngine;

namespace Duo1J
{
    public class AVGActionDefault : MonoBehaviour, Duo1JAction
    {
        public void GetButtonChoose(string eventTag, Choose choose)
        {
            Debug.Log(eventTag + ": " + choose.Index + " " + choose.Text);
        }
    }
}
