using System;
using UnityEngine;

namespace Assets.Scripts.Player_Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlatformController : MonoBehaviour
    {
        [SerializeField]
        protected Vector3[] WayPoints;

        protected Vector3[] GlobalWayPoints;

        [SerializeField]
        public float Speed = 2;
        [SerializeField]
        bool _cyclic = true;
        [SerializeField]
        float _waitTime = 0.5f;
        [SerializeField]
        bool isObstacle;
        [SerializeField]
        float _easeAmount = 0;

        int _waypointIndex;
        float _distancePercent;
        float _timeToMove;

        void Start()
        {
            GlobalWayPoints = new Vector3[WayPoints.Length];
            for (int i = 0; i < WayPoints.Length; i++)
                GlobalWayPoints[i] = WayPoints[i] + transform.position;
        }

        void Update()
        {
            if (WayPoints == null || WayPoints.Length < 1) return;
            Vector3 velocity = CalculateMovement();
            transform.Translate(velocity);
        }

        float Ease(float x)
        {
            float a = _easeAmount + 1;
            return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
        }

        Vector3 CalculateMovement()
        {
           if (!isObstacle && Time.timeScale > 0.000001f && Time.time * (1 / (Time.timeScale / Time.timeScale)) < _timeToMove)
                return Vector3.zero;

           if (Time.time < _timeToMove)
                return Vector3.zero;

            _waypointIndex %= GlobalWayPoints.Length;

            int toWaypointIndex = (_waypointIndex + 1) % GlobalWayPoints.Length;
            float distanceBetweenWaypoints = Vector3.Distance(GlobalWayPoints[_waypointIndex], GlobalWayPoints[toWaypointIndex]);

            if (!isObstacle && Time.timeScale > 0.000001f)
                _distancePercent += Time.deltaTime * Speed * (1 / Time.timeScale) / distanceBetweenWaypoints;
            else if (isObstacle)
                _distancePercent += Time.deltaTime * Speed / distanceBetweenWaypoints;

            _distancePercent = Mathf.Clamp01(_distancePercent);
            float easedPercentBetweenWaypoints = Ease(_distancePercent);

            Vector3 newPos = Vector3.Lerp(GlobalWayPoints[_waypointIndex], GlobalWayPoints[toWaypointIndex], easedPercentBetweenWaypoints);

            if (!(_distancePercent >= 1)) return newPos - transform.position;

            _distancePercent = 0;
            _waypointIndex++;

            if (!_cyclic)
            {
                if (_waypointIndex >= GlobalWayPoints.Length - 1)
                {
                    _waypointIndex = 0;
                    Array.Reverse(GlobalWayPoints);
                }
            }

            if (!isObstacle && Time.timeScale > 0.000001f)
                _timeToMove = Time.time * (1 / (Time.timeScale / Time.timeScale)) + _waitTime;
            else if(isObstacle)
                _timeToMove = Time.time + _waitTime;

            return newPos - transform.position;
        }

        void OnDrawGizmos()
        {
            if (WayPoints == null) return;

            Gizmos.color = Color.red;
            const float size = .3f;

            for (int i = 0; i < WayPoints.Length; i++)
            {
                Vector3 globalWaypointPos = Application.isPlaying ? GlobalWayPoints[i] : WayPoints[i] + transform.position;
                Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
                Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
            }
        }
    }
}
