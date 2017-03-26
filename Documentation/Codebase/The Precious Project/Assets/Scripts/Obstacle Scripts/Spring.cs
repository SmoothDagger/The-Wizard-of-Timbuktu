using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(AudioSource))]
public class Spring : MonoBehaviour
{
    [SerializeField] float jumpVelocityMultiplier = 1.5f;
    readonly Vector3 _down = new Vector3(0, 0.75f, 0);
    Transform _platform;

    PlayerController _player;
    Transform playerTransform;

    AudioSource _audio;

    void Start()
    {
        _platform = transform.parent;
        GameObject player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerController>();
        playerTransform = player.transform;
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PushDown();
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PushUp();
            playerTransform.position = new Vector3(playerTransform.position.x, _platform.position.y + 1f, playerTransform.position.z);
            _player.Spring(jumpVelocityMultiplier);
            _audio.Play();
        }        
    }

    void PushUp()
    {
        _platform.localPosition = Vector3.up;
    }

    void PushDown()
    {
        _platform.localPosition = _down;
    }
}
