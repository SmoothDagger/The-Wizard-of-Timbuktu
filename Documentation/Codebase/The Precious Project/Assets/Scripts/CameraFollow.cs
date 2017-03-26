using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _levelTop;
        public Vector3 _levelLeft;
        private Vector3 _levelRight;
        private Vector3 _levelBottom;
        private Camera _camera;
        private float _halfHeight;
        private float _halfWidth;
        private Vector3 _velocity;
        private float _smoothTime;
        Vector3 playerTop;
        Vector3 playerBot;
        Vector3 playerRight;
        Vector3 playerLeft;

        private void Start()
        {
            _smoothTime = 0.9f;
            _target = GameObject.FindWithTag("Player").transform;
            _levelTop = GameObject.FindWithTag("LevelTop").transform.position;
            _levelBottom = GameObject.FindWithTag("LevelBottom").transform.position;
            _levelLeft = GameObject.FindWithTag("LevelLeft").transform.position;
            _levelRight = GameObject.FindWithTag("LevelRight").transform.position;
            _camera = GetComponent<Camera>();
            _halfHeight = _camera.orthographicSize;
            _halfWidth = _camera.aspect * _halfHeight;
            _velocity = Vector3.zero;
        }

        private void LateUpdate()
        {
            Vector3 cameraZ = new Vector3(Input.GetAxisRaw("Horizontal") * 5, 3, -15);
            if (_target.forward.z == -1)
            {
                cameraZ.z *= -1;
            }
            Vector3 targetPosition = _target.TransformPoint(cameraZ);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _levelLeft.x + _halfWidth, _levelRight.x - _halfWidth),
                 Mathf.Clamp(transform.position.y, _levelBottom.y, _levelTop.y - _halfHeight), transform.position.z);
        }
    }
}
