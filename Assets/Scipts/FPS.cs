using UnityEngine;

namespace CrazyEight
{
	public class FPS : MonoBehaviour
	{
        private void Update()
        {

            float fps = 1.0f / Time.deltaTime;
            Debug.Log(fps);
        }
	}
}
