using UnityEngine;

namespace CrazyEight
{
	public class CameraMove : MonoBehaviour
	{
        [SerializeField] private GameObject _player;

        private void Update()
        {
            transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
