using UnityEngine;

namespace CrazyEight
{
	public class DeadCharapter : MonoBehaviour
	{
        [SerializeField] private GameObject _uiDeadPanel;
        [SerializeField] private GameObject _deadEffect;

        private void OnEnable()
        {
            Coliciont.OnDead += Dead;
        }
        private void OnDisable()
        {
            Coliciont.OnDead -= Dead;
        }

        private void Dead()
        {
            Instantiate(_deadEffect,transform.position,Quaternion.identity);
            Invoke(nameof(UiDead),0.45f);
            gameObject.SetActive(false);
        }
        private void UiDead()
        {
            _uiDeadPanel.SetActive(true);
        }
    }
}
