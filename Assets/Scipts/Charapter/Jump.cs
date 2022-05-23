using UnityEngine;

namespace CrazyEight
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] private GameObject _effectJump;
        private Rigidbody2D _rigidbody;

        private float _forceJump = 325;

        //private bool _twoJump = false;
        private bool _ground =true;
        private bool _doubleJump;

        private void OnEnable()
        {
            InputControll.OnJump += JumpCharapter;
            Coliciont.OnGround += GroundChek;
            TrigerCollider.OnDoubleJump += DoubleJumpChek;
        }
        private void OnDisable()
        {
            InputControll.OnJump -= JumpCharapter;
            Coliciont.OnGround -= GroundChek;
            TrigerCollider.OnDoubleJump += DoubleJumpChek;
        }


        private void Start()
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
        }
        private void DoubleJumpChek(bool doubleJump)
        {
            _doubleJump = doubleJump;
        }

        private void GroundChek(bool ground)
        {
            _ground = ground;
            //_twoJump = false;
        }

        private void JumpCharapter()
        {

            if ((_ground || _doubleJump))
            {

                if (_doubleJump)
                {
                    //_twoJump = true;
                    var efecct = Instantiate(_effectJump, new Vector2(transform.position.x,transform.position.y -0.5f), Quaternion.identity);
                    Destroy(efecct, 0.4F);
                }
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.AddForce(Vector2.up * _forceJump);
            }
        }
    }
}
