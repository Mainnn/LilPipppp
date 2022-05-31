using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrazyEight
{
	public class UiButton : MonoBehaviour
	{
        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
 