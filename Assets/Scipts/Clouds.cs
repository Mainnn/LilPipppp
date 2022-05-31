using UnityEngine;

namespace CrazyEight
{
	public class Clouds : MonoBehaviour
	{
        private float _speedClouds; 

        private void Start()
        {
            _speedClouds = Random.Range(0.25f,0.75f);
        }
        private void Update()
        {
            transform.Translate(new Vector3(-1, 0, 0)*_speedClouds*Time.deltaTime);
        }
    }
}
