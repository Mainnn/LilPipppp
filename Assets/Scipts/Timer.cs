using UnityEngine;
using UnityEngine.UI;

namespace CrazyEight
{
	public class Timer : MonoBehaviour
	{
        [SerializeField] private Text _text;

        private float _timeRun;

        public float TimeRun => _timeRun;

        private void Update()
        {
            _timeRun += Time.deltaTime;
            _text.text = "Time:" + _timeRun.ToString("0.00");
        }
    }
}
