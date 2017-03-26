using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SlipperyObstacle : MonoBehaviour
{
    AudioSource _audio;
    PlayerController _player;
    Transform _playerTransform;

    ParticleSystem _particle;
    Transform _particleTransform;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        GameObject player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerController>();
        _playerTransform = player.transform;

        _particleTransform = transform.GetChild(0);
        _particle = _particleTransform.gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(_player.Sliding)
        {
            _particleTransform.position = _playerTransform.position;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other == null || !other.CompareTag("Player")) return;

        if(_player.IsMoving())
        {
            _player.Sliding = true;
            _player.SpeedUp();
        }
            

        if (_player.Sliding && _player.IsPlayerGrounded() && !_audio.isPlaying)
        {
            _particle.Play();
            _audio.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == null || !other.CompareTag("Player")) return;

        _player.Sliding = false;
        _player.SameSpeed();
    }
}