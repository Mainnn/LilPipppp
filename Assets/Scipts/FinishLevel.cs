using UnityEngine;

namespace CrazyEight
{
	public class FinishLevel : MonoBehaviour
	{
        [SerializeField] private GameObject _UiWin;
        private void OnEnable()
        {
            FinishCheker.OnFinished += WinLevel;
        }
        private void OnDisable()
        {
            FinishCheker.OnFinished -= WinLevel;
        }

        private void WinLevel()
        {
            _UiWin.SetActive(true);
        }
    }
}
