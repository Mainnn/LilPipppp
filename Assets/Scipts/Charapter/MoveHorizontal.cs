using UnityEngine;

namespace CrazyEight
{
	public class MoveHorizontal : MonoBehaviour
	{
        private float _directionVector;
        private float _speed =6.0f;
        private bool _facingRight =true;

        private void OnEnable()
        {
            InputControll.OnMove += MoveCharapter;
        }
        private void OnDisable()
        {
            InputControll.OnMove -= MoveCharapter;
        }

        private void MoveCharapter(float _directionVector)
        {
            transform.Translate(Vector3.right * (_directionVector * _speed) * Time.deltaTime);

            if (_directionVector < 0 && _facingRight)
            {
                Flip();
            }
            else if (_directionVector > 0 && !_facingRight)
            {
                Flip();
            }
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
}
