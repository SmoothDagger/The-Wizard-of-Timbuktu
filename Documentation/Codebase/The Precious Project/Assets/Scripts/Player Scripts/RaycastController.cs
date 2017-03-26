using UnityEngine;

namespace Assets.Scripts.Player_Scripts
{
    public class RaycastController
    {
        public int HorizontalRayCount = 4;
        public int VerticalRayCount = 4;

        public LayerMask CollisionMask;

        public const float SkinWidth = 0.015f;

        public float VerticalRaySpacing;
        public float HorizontalRaySpacing;

        public RaycastOrigins RaycastOrigin;

        Bounds _bounds;

        public RaycastController(Collider collider, LayerMask mask)
        {
            CollisionMask = mask;

            _bounds = collider.bounds;
            _bounds.Expand(SkinWidth*-2);
            CalculateRaySpacing();
        }

        public void UpdateRayOrigins()
        {
            RaycastOrigin.TopLeft = new Vector3(_bounds.min.x, _bounds.max.y, _bounds.center.z);
            RaycastOrigin.TopRight = new Vector3(_bounds.max.x, _bounds.max.y, _bounds.center.z);

            RaycastOrigin.BottomLeft = new Vector3(_bounds.min.x, _bounds.min.y, _bounds.center.z);
            RaycastOrigin.BottomRight = new Vector3(_bounds.max.x, _bounds.min.y, _bounds.center.z);
        }

        void CalculateRaySpacing()
        {
            HorizontalRayCount = Mathf.Clamp(HorizontalRayCount, 2, int.MaxValue);
            VerticalRayCount = Mathf.Clamp(VerticalRayCount, 2, int.MaxValue);

            HorizontalRaySpacing = _bounds.size.y / (HorizontalRayCount - 1);
            VerticalRaySpacing = _bounds.size.x / (VerticalRayCount - 1);
        }

        public struct RaycastOrigins
        {
            public Vector3 TopLeft, TopRight;
            public Vector3 BottomLeft, BottomRight;
        }

        //Helper Functions
        public struct Cons
        {
            public const float Tolerance = 0.001f;
        }

    }
}
