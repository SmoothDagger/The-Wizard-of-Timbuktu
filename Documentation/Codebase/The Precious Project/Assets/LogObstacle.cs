using Assets.Scripts.Effects;
using UnityEngine;

namespace Assets.Scripts.Obstacle_Scripts
{
    // Attached to Obstacles - Player object must have the "Player" tag
    public class LogObstacle : MonoBehaviour
    {
        public bool CanKill = true;
        public GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        void OnTriggerEnter(Collider objectCollider)
        {
            if (transform.parent.GetComponent<Rigidbody>().velocity.y <= -1)
            {
                if (CanKill && objectCollider.tag == "Player")
                {
                    player.GetComponent<PlayerController>().timesKilledByFallingLog++;
                    player.GetComponent<PlayerController>().isKilledByFallingLog = true;
                    objectCollider.GetComponent<PlayerController>().Die();
                    GameObject global = GameObject.FindWithTag("Global");
                    if (global)
                        global.GetComponent<GetObjectsPosition>().Reset();
                }
            }
        }

        void Update()
        {
            if (!player.GetComponent<PlayerController>().IsAlive)
            {
                transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                transform.parent.parent.GetComponent<ParentScriptForTrigger>().ResetTrap();
            }
        }
    }
}
