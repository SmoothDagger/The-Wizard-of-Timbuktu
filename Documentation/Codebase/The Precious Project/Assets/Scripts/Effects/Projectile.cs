using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class Projectile : MonoBehaviour
    {
        private float _direction;
        private Vector3 _travelVector3 = Vector3.zero;

        //Sets direction of the projectile
        public void SetDirection(Transform objTransformform)
        {
            var pos = objTransformform.position;
            transform.position = new Vector3(pos.x + 1.5f * objTransformform.right.x,
                pos.y, pos.z);
            _direction = objTransformform.right.x;
        }

        private void OnEnable()
        {
            transform.TransformDirection(_travelVector3);
        }

        private void Update()
        {
            _travelVector3 = transform.TransformDirection(_travelVector3);
            _travelVector3.x = 5f*_direction*Time.deltaTime;
            transform.Translate(_travelVector3);
        }

        //Freeze obstacle if hit then destroys projectiles
        private void OnTriggerEnter(Collider objectCollider)
        {
            if (objectCollider.CompareTag("Obstacle"))
                objectCollider.gameObject.AddComponent<Effect>();
        
            Destroy(gameObject);
        }
    }
}