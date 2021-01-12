using UnityEngine;

namespace Player.Props
{
    public class PlayerProps : MonoBehaviour
    {
        public static int Depth { set; get; }
        public static bool InFront { get; set; } = false;
        private void Start()
        {
            Depth = 0;
        }
    }
}