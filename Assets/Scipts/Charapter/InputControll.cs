using System;
using UnityEngine;

namespace CrazyEight
{
	public class InputControll : MonoBehaviour
	{
        [SerializeField] private Joystick _jotstik;
        private float _inputHorizontal;

        public static Action <float> OnMove;
        public static Action OnJump;
        public static Action OnDash;

        private void Start()
        {
#if UNITY_EDITOR
            Application.targetFrameRate = 999999;
#elif UNITY_ANDROID
            Application.targetFrameRate = 60;
#endif
            Time.timeScale = 1;
        }

        private void Update()
        {
            
#if UNITY_EDITOR
            _inputHorizontal = Input.GetAxis("Horizontal");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ImputJump();
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                InputDash();
            }

#elif UNITY_ANDROID
            _inputHorizontal = _jotstik.Horizontal;
#endif
            OnMove?.Invoke(_inputHorizontal);
        }

        public void  ImputJump()
        {
            OnJump?.Invoke();
        }
        public void InputDash()
        {
            OnDash?.Invoke();
        }
    }
}
