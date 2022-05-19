using UnityEngine;

namespace CrazyEight
{
	public class Animation : MonoBehaviour
	{
		private Animator _anim;

        private void OnEnable()
        {
            CharapterState.OnStait += AnimManager;
        }
        private void OnDisable()
        {
            CharapterState.OnStait -= AnimManager;
        }

        private void Start()
        {
            _anim = transform.GetComponent<Animator>();
        }
        private void AnimManager(State state)
        {
            _anim.SetBool("Run", state.IsRun);
            _anim.SetBool("Jump", state.IsJump);
            _anim.SetBool("Idie", state.IsIdle);
        }

    }
}
