using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider))]
    public class Checkpoint : MonoBehaviour
    {
        private bool _activated;
        private Transform _spawnPoint;

        void Start()
        {
            _spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        }

        void OnTriggerEnter(Collider other)
        {
            if (_activated || !other.CompareTag("Player")) return;

            _activated = true;
            _spawnPoint.position = transform.position;

            TimerReset(other.GetComponent<Timer>());            
        }

        void TimerReset(Timer timer)
        {
            timer.ResetTime(false);
            timer.checkpointTime = 0.0f;
        }
    }
}
