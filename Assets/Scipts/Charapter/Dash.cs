using System;
using UnityEngine;

namespace CrazyEight
{
	public class Dash : MonoBehaviour
	{
        [SerializeField] private GameObject _effectDash;
        GameObject effectDahs = null;
        private Vector2 _OffsetDashEffect;
        //Страшно вырубай!!!
        private Rigidbody2D _rigidbody;

        private float _forceDash = 10f;
        private float _startDashTimer = 0.2f;
        private float _currentDashtimer;
        private float _dashDirection;

        private float _dashPositionY;
        private bool _isDashing;

        private bool _doubleDash;

        private bool _isDashTarget;

        private void Start()
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputControll.OnDash += DashCharapter;
            TrigerCollider.OnDashTarget += DashTarget;
            Coliciont.OnGround += GroundChek;

        }
        private void OnDisable()
        {
            InputControll.OnDash -= DashCharapter;
            TrigerCollider.OnDashTarget -= DashTarget;
            Coliciont.OnGround -= GroundChek;
        }
        private void FixedUpdate()
        {
            if ((_isDashing || _isDashTarget)&& _doubleDash)
            {
                _OffsetDashEffect = new Vector2(transform.position.x - (0.5f * transform.localScale.x), transform.position.y);
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.velocity = transform.right * _dashDirection * _forceDash;
                transform.position = new Vector3(transform.position.x, _dashPositionY);
                _currentDashtimer -= Time.deltaTime;
                if (effectDahs == null)
                {
                    effectDahs = Instantiate(_effectDash, _OffsetDashEffect, _effectDash.transform.rotation);
                    effectDahs.transform.parent = transform;
                    effectDahs.transform.localScale = _effectDash.transform.localScale;
                    Destroy(effectDahs, 0.26f);
                }
                if (_currentDashtimer <= 0)
                {
                    _rigidbody.velocity = Vector2.zero;
                    _isDashing = false;
                    _isDashTarget = false;
                    _doubleDash = false;
                }
            }
        }
        private void DashCharapter()
        {
            if (_doubleDash)
            {
                _dashPositionY = transform.position.y;
                _currentDashtimer = _startDashTimer;
                _isDashing = true;
                _dashDirection = transform.localScale.x;
            }
        }
        private void DashTarget(bool isDashTarget)
        {
            _isDashTarget = isDashTarget;
            _doubleDash = true;
            _dashPositionY = transform.position.y;
        }
        private void GroundChek(bool ground)
        {
            if (ground)
            {
                _doubleDash = true;
            }
        }
    }
}
