using System;
using UnityEngine;

namespace CrazyEight
{
	public class CharapterState : MonoBehaviour
	{
        private bool _isjump;
        private bool _isGround;
        private float _horizontal;

        private State _state;

        public static Action<State> OnStait;

        private void Start()
        {
            _state = new State();
        }

        private void OnEnable()
        {
            Coliciont.OnGround += GroundChek;
            InputControll.OnJump += JumpCharapter;
            InputControll.OnMove += Move;
        }
        private void OnDisable()
        {
            Coliciont.OnGround -= GroundChek;
            InputControll.OnJump -= JumpCharapter;
            InputControll.OnMove -= Move;
        }

        private void GroundChek(bool isGround)
        {
            this._isGround = isGround;
            SetStayts();
        }
        private void JumpCharapter()
        {
            _isjump = true;
            SetStayts();
        }
        private void Move(float valume)
        {
            _horizontal = valume;
            SetStayts();
        }
        public void SetStayts()
        {
            if((_horizontal != 0) && _isGround)
            {
                _state.IsRun = true;
                _state.IsIdle = false;
                _state.IsJump = false;
            }
            else if((_horizontal == 0) && _isGround )
            {
                _state.IsRun = false;
                _state.IsIdle = true;
                _state.IsJump = false;
            }
            else if (_isjump && !_isGround)
            {
                _state.IsRun = false;
                _state.IsIdle = false;
                _state.IsJump = true;
            }
            OnStait?.Invoke(_state);
        }
    }
    public  class State
    {
        public bool IsIdle;
        public bool IsRun;
        public bool IsJump;
    }
}