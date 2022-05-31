using System;
using UnityEngine;

namespace CrazyEight
{
	public class FinishCheker : MonoBehaviour
    {
        public static Action OnFinished;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<CharapterState>(out CharapterState charapter))
            {
                OnFinished?.Invoke();
            }
        }
    }
}
