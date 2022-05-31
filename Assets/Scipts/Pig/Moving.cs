using UnityEngine;

namespace CrazyEight
{
	public class Moving : MonoBehaviour
	{
		[SerializeField] private Transform _firstTarget;
        [SerializeField] private Transform _secondTarget;

        private Transform _targetNow;

        private float _speed =2f;

        private void Start()
        {
            _targetNow = _firstTarget;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetNow.position, _speed * Time.deltaTime);
            ChekTarget();
        }
        private void Flip()
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }

        private void ChekTarget()
        {
            if (transform.position.x <= _firstTarget.position.x)
            {
                _targetNow = _secondTarget;
                Flip();
            }
            else if (transform.position.x >= _secondTarget.position.x)
            {
                _targetNow = _firstTarget;
                Flip();
            }
        }
    }
}
