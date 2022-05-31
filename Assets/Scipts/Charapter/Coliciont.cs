using System;
using UnityEngine;

namespace CrazyEight
{
	public class Coliciont : MonoBehaviour
	{
        public static Action<bool> OnGround;
        public static Action OnDead;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            {
                OnGround?.Invoke(true);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Barier>(out Barier barier))
            {
                OnDead?.Invoke();
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
