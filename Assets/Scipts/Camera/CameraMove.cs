using UnityEngine;

namespace CrazyEight
{
	public class CameraMove : MonoBehaviour
	{
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;

        private Camera _camera;

        private float _cameraYSize = 5;
        private float _cameraXSize = 9;

        private float _leftBorder;
        private float _rightBorder;
        private float _upperBorder;
        private float _lowerBorder;

        private void Start()
        {
            _leftBorder = _left.position.x;
            _lowerBorder = _left.position.y;
            _rightBorder = _right.position.x;
            _upperBorder = _right.position.y;
            _camera = Camera.main;
        }


        private void Update()
        {
            if ((_leftBorder <= _player.position.x - _cameraXSize) && (_rightBorder >= _player.position.x + _cameraXSize))
            {
                transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
            }
            if (_player.position.y >= _lowerBorder + _cameraYSize &&  _player.position.y <= _upperBorder - _cameraYSize)
            {
                transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);
            }
        }
    }
}
