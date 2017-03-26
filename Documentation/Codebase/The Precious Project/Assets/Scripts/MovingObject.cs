using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class MovingObject : MonoBehaviour 
    {
        [SerializeField]
        protected Vector3[] LocalWayPoints;

        protected Vector3[] GlobalWayPoints;

        [SerializeField]
        float _speed = 2;
        [SerializeField]
        bool _cyclic = true;
        [SerializeField]
        float _waitTime = 0.5f;

        [SerializeField]
        float _easeAmount = 0;

        int _waypointIndex;
        float _distancePercent;
        float _timeToMove;

        protected virtual void Start()
        {
            GlobalWayPoints = new Vector3[LocalWayPoints.Length];
            for (int i = 0; i < LocalWayPoints.Length; i++)
                GlobalWayPoints[i] = LocalWayPoints[i] + transform.position;
        }

        float Ease(float x)
        {
            float a = _easeAmount + 1;
            return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
        }

        protected Vector3 CalculateObjectMovement()
        {
            if (Time.time < _timeToMove)
            {
                return Vector3.zero;
            }

            //Bug: Zero Division
            _waypointIndex %= GlobalWayPoints.Length;
            //end

            int toWaypointIndex = (_waypointIndex + 1) % GlobalWayPoints.Length;
            float distanceBetweenWaypoints = Vector3.Distance(GlobalWayPoints[_waypointIndex], GlobalWayPoints[toWaypointIndex]);
            _distancePercent += Time.deltaTime * _speed / distanceBetweenWaypoints;
            _distancePercent = Mathf.Clamp01(_distancePercent);
            float easedPercentBetweenWaypoints = Ease(_distancePercent);

            Vector3 newPos = Vector3.Lerp(GlobalWayPoints[_waypointIndex], GlobalWayPoints[toWaypointIndex], easedPercentBetweenWaypoints);

            if (_distancePercent >= 1)
            {
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
                _timeToMove = Time.time + _waitTime;
            }

            return newPos - transform.position;
        }

    }
}
