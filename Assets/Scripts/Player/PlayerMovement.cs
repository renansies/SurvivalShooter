using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 6f;

        private Vector3 _movement;
        private Animator _anim;
        private Rigidbody _playerRigidbody;
        private int _floorMask;
        private float _camRayLength = 100f;

        private void Awake()
        {
            _floorMask = LayerMask.GetMask("Floor");
            _anim = GetComponent<Animator>();
            _playerRigidbody = GetComponent<Rigidbody>();
            
        }

        private void FixedUpdate()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            
            Move(h, v);
            Turning();
            Animating(h, v);
        }

        private void Move(float h, float v)
        {
            _movement.Set(h, 0f, v);

            _movement = _movement.normalized * Speed * Time.deltaTime;
            _playerRigidbody.MovePosition(transform.position + _movement);
        }

        private void Turning()
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, _camRayLength, _floorMask))
            {
                var playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;

                var newRotation = Quaternion.LookRotation(playerToMouse);
                _playerRigidbody.MoveRotation(newRotation);
            }
        }

        private void Animating(float h, float v)
        {
            var walking = h != 0f || v != 0f;
            _anim.SetBool("IsWalking", walking);
        }
    }
}
