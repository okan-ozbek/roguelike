using UnityEngine;

namespace Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        public delegate void Default();

        public static event Default Dead;
        public static event Default Win;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Dead?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Win?.Invoke();
            }
            
        }

        private void SomeFunc(int num, AudioClip clip, Animation anim)
        {
            // asdasdasd
        }
    }
}