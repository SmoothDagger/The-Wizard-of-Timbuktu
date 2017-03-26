using UnityEngine;

namespace Assets.Scripts.Player_Scripts
{
    [RequireComponent(typeof(Controller))]
    public class Player : MonoBehaviour
    {
        [SerializeField] float _maxJumpHeight = 4f;
        [SerializeField] float _minJumpHeight = 4f;
        [SerializeField] float _timeToJumpApex = 0.4f;
        [SerializeField] float _deltaTimeAirborne = 0.2f;
        [SerializeField] float _deltaTimeGrounded = 0.1f;

        float _moveSpeed = 6;

        float _gravity;
        float _maxJumpVelocity;
        float _minJumpVelocity;
        Vector3 _velocity;
        float _velocityXSmoothing;
        Controller _controller;

        void Start()
        {
            _controller = GetComponent<Controller>();
            _gravity = -(2*_maxJumpHeight)/Mathf.Pow(_timeToJumpApex, 2);
            _maxJumpVelocity = Mathf.Abs(_gravity)*_timeToJumpApex;
            _minJumpVelocity = Mathf.Sqrt(2*Mathf.Abs(_gravity)*_minJumpHeight);
        }

        void Update()
        {
            if (_controller.Collisions.Above || _controller.Collisions.Below)
                _velocity.y = 0;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (Input.GetButtonDown("Jump") && _controller.Collisions.Below)
            {
                _velocity.y = _maxJumpVelocity;
            }

            if (Input.GetButtonUp("Jump"))
            {
                if(_velocity.y > _minJumpVelocity)
                _velocity.y = _minJumpVelocity;
            }
               

            float targetVelocityX = input.x*_moveSpeed;
            _velocity.x = Mathf.SmoothDamp(_velocity.x, targetVelocityX, ref _velocityXSmoothing, _controller.Collisions.Below? _deltaTimeGrounded : _deltaTimeAirborne);
            _velocity.y += _gravity*Time.deltaTime;
            _controller.Move(_velocity*Time.deltaTime);
        }
    }
}