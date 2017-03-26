using System;
using UnityEngine;

namespace Assets.Scripts.Player_Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Controller : MonoBehaviour
    {
        [SerializeField] float _maxClimbAngle = 80;
        [SerializeField] float _maxDescendAngle = 80;

        public CollisionInfo Collisions;

        RaycastController _raycaster;
        float _skinWidth = RaycastController.SkinWidth;
        const float Tolerance = RaycastController.Cons.Tolerance;

        void Start()
        {
            _raycaster = new RaycastController(GetComponent<BoxCollider>(), LayerMask.GetMask("Platform"));
        }

        public void Move(Vector3 velocity, bool onPlatform = false)
        {
            _raycaster.UpdateRayOrigins();
            Collisions.Reset();

            Collisions.OldVelocity = velocity;

            if (velocity.y < 0)
                DescendSlope(ref velocity);

            if (Math.Abs(velocity.x) > Tolerance)
                HorizontalCollisions(ref velocity);

            if (Math.Abs(velocity.y) > Tolerance)
                VerticalCollisions(ref velocity);

            transform.Translate(velocity);

            if (onPlatform)
                Collisions.Below = true;
        }

        void HorizontalCollisions(ref Vector3 velocity)
        {
            float directionX = Mathf.Sign(velocity.x);
            float rayLength = Mathf.Abs(velocity.x) + _skinWidth;
            bool reversed = directionX < 0;

            for (int i = 0; i < _raycaster.HorizontalRayCount; i++)
            {
                Vector3 rayOrigin = reversed ? _raycaster.RaycastOrigin.BottomLeft : _raycaster.RaycastOrigin.BottomRight;
                rayOrigin += Vector3.up*_raycaster.HorizontalRaySpacing*i;

                Debug.DrawRay(rayOrigin, Vector3.right*directionX*rayLength, Color.cyan);

                RaycastHit hit;

                if (!Physics.Raycast(rayOrigin, Vector3.right*directionX, out hit, rayLength, _raycaster.CollisionMask)) continue;

                if (Math.Abs(hit.distance) < Tolerance) continue;
                float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

                if (i == 0 && slopeAngle <= _maxClimbAngle)
                {
                    if (Collisions.DescendingSlope)
                    {
                        Collisions.DescendingSlope = false;
                        velocity = Collisions.OldVelocity;
                    }

                    float distanceToSlopeStart = 0;

                    if (Mathf.Abs(slopeAngle - Collisions.OldSlopeAngle) > Tolerance)
                    {
                        distanceToSlopeStart = hit.distance - _skinWidth;
                        velocity.x -= distanceToSlopeStart*directionX;
                    }

                    ClimbSlope(ref velocity, slopeAngle);
                    velocity.x += distanceToSlopeStart * directionX;
                }

                if(Collisions.ClimbingSlope && slopeAngle <= _maxClimbAngle) continue;

                velocity.x = (hit.distance - _skinWidth)*directionX;
                rayLength = hit.distance;

                if (Collisions.ClimbingSlope)
                    velocity.y = Mathf.Tan(Collisions.SlopeAngle*Mathf.Deg2Rad)*Mathf.Abs(velocity.x);

                Collisions.Left = reversed;
                Collisions.Right = !reversed;
            }
        }

        void VerticalCollisions(ref Vector3 velocity)
        {
            float directionY = Mathf.Sign(velocity.y);
            float rayLength = Mathf.Abs(velocity.y) + _skinWidth;
            bool reversed = directionY < 0;

            for (int i = 0; i < _raycaster.VerticalRayCount; i++)
            {
                Vector3 rayOrigin = reversed ? _raycaster.RaycastOrigin.BottomLeft : _raycaster.RaycastOrigin.TopLeft;
                rayOrigin += Vector3.right*(_raycaster.VerticalRaySpacing*i + velocity.x);

                Debug.DrawRay(rayOrigin, Vector3.up*directionY*rayLength, Color.cyan);

                RaycastHit hit;

                if (!Physics.Raycast(rayOrigin, Vector3.up*directionY, out hit, rayLength, _raycaster.CollisionMask)) continue;

                velocity.y = (hit.distance - _skinWidth)*directionY;
                rayLength = hit.distance;

                if (Collisions.ClimbingSlope)
                    velocity.x = velocity.y/Mathf.Tan(Collisions.SlopeAngle*Mathf.Deg2Rad)*Mathf.Sign(velocity.x);

                Collisions.Below = reversed;
                Collisions.Above = !reversed;
            }

            if (Collisions.ClimbingSlope)
            {
                float directionX = Mathf.Sign(velocity.x);
                rayLength = Mathf.Abs(velocity.x) + _skinWidth;
                Vector3 rayOrigin = (directionX < 0? _raycaster.RaycastOrigin.BottomLeft
                                    : _raycaster.RaycastOrigin.BottomRight) + Vector3.up*velocity.y;

                RaycastHit hit;

                if (!Physics.Raycast(rayOrigin, Vector3.right*directionX, out hit, rayLength, _raycaster.CollisionMask)) return;

                float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

                if (!(Mathf.Abs(slopeAngle - Collisions.SlopeAngle) > Tolerance)) return;

                velocity.x = (hit.distance - _skinWidth)*directionX;
                Collisions.SlopeAngle = slopeAngle;
            }
        }

        void ClimbSlope(ref Vector3 velocity, float slopeAngle)
        {
            float distance = Mathf.Abs(velocity.x);
            float slopeAngleInRad = slopeAngle * Mathf.Deg2Rad;
            float climbVelocityY = Mathf.Sin(slopeAngleInRad) * distance;

            if (velocity.y > climbVelocityY) return;

            velocity.y = climbVelocityY;
            velocity.x = Mathf.Cos(slopeAngleInRad) *distance*Mathf.Sign(velocity.x);
            Collisions.Below = true;
            Collisions.ClimbingSlope = true;
            Collisions.SlopeAngle = slopeAngle;
        }

        void DescendSlope(ref Vector3 velocity)
        {
            float directionX = Mathf.Sign(velocity.x);
            Vector3 rayOrigin = directionX < 0 ? _raycaster.RaycastOrigin.BottomRight : _raycaster.RaycastOrigin.BottomLeft;

            RaycastHit hit;

            if (!Physics.Raycast(rayOrigin, Vector3.right * directionX, out hit, _raycaster.CollisionMask)) return;

            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);

            if (Mathf.Abs(slopeAngle) <= Tolerance && slopeAngle > _maxDescendAngle &&
                Mathf.Abs(Mathf.Sign(hit.normal.x) - directionX) >= Tolerance) return;

            float slopeAngleInRad = slopeAngle*Mathf.Deg2Rad;
            float distance = Mathf.Abs(velocity.x);

            if (hit.distance - _skinWidth > Mathf.Tan(slopeAngleInRad)*distance) return;

            float descendVelocityY = Mathf.Sin(slopeAngleInRad) * distance;

            velocity.x = Mathf.Cos(slopeAngleInRad) * distance * directionX;
            velocity.y -= descendVelocityY;

            Collisions.SlopeAngle = slopeAngle;
            Collisions.DescendingSlope = true;
            Collisions.Below = true;
        }

        public struct CollisionInfo
        {
            public bool Above, Below;
            public bool Left, Right;

            public bool ClimbingSlope;
            public bool DescendingSlope;

            public float SlopeAngle, OldSlopeAngle;
            public Vector3 OldVelocity;

            public void Reset()
            {
                Above = Below = false;
                Left = Right = false;
                ClimbingSlope = false;
                DescendingSlope = false;

                OldSlopeAngle = SlopeAngle;
                SlopeAngle = 0;
            }
        }
    }
}
