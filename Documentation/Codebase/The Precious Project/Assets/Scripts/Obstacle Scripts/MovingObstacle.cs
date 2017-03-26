using UnityEngine;

namespace Assets.Scripts.Obstacle_Scripts
{
    public class MovingObstacle : Obstacles
    {
        [SerializeField] private Vector3 _destination = Vector3.zero;
        [SerializeField] private float _speed = 2.5f;
        [SerializeField] private bool CanRotate = true;
        [SerializeField] private bool CanDisplace = true;

        private void Update()
        {
            if (CanRotate)
                transform.Rotate(new Vector3(0, 0, 1), _speed * 100f * Time.deltaTime);
            if (CanDisplace)
                transform.position = Vector3.Lerp(transform.position, _destination, Time.deltaTime);
        }
    }
}