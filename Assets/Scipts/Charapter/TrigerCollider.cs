using System;
using UnityEngine;

namespace CrazyEight
{
	public class TrigerCollider : MonoBehaviour
	{
        [SerializeField] private CharapterState _state;
        [SerializeField] private GameObject effectDestroi;

        public static Action<bool> OnDoubleJump;
        public static Action<bool> OnDashTarget;

        private void Start()
        {
            _state = _state.GetComponent < CharapterState>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<JumpPlatform>(out JumpPlatform jumpPlatform))
            {
                OnDoubleJump?.Invoke(true);
                Time.timeScale = 0.75f;
            }
            if (collision.gameObject.TryGetComponent<DashTarget>(out DashTarget dashTarget))
            {
                OnDashTarget?.Invoke(true);
                Time.timeScale = 0.75f;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<JumpPlatform>(out JumpPlatform jumpPlatform))
            {
                OnDoubleJump?.Invoke(false);
                Time.timeScale = 1;
            }
            if(collision.gameObject.TryGetComponent<DashTarget>(out DashTarget dashTarget))
            {
                OnDashTarget?.Invoke(false);
                Time.timeScale = 1;
            }
        }

        private void Effect(Collider2D collision)
        {
            var effect = Instantiate(effectDestroi, collision.transform.position, Quaternion.identity);
            Destroy(effect,0.45f);
            Destroy(collision.gameObject, 0.35f);
        }
    }
    
}
