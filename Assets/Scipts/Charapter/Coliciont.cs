using System;
using UnityEngine;

namespace CrazyEight
{
	public class Coliciont : MonoBehaviour
	{
        public static Action<bool> OnGround;


        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            {
                OnGround?.Invoke(true);
                
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            {
                OnGround?.Invoke(false);
            }
        }

    }
}
