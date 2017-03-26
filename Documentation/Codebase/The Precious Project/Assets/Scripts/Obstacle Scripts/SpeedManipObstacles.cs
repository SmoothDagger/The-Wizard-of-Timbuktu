using UnityEngine;

 public class SpeedManipObstacles : MonoBehaviour
{
    [SerializeField]
    bool _speedDown;


    void OnTriggerStay(Collider other)
    {
        if (other == null || !other.CompareTag("Player")) return;
        PlayerController player = other.GetComponent<PlayerController>();

        if(_speedDown)
            player.SlowDown();
        else
            player.SpeedUp();

        if (tag.Equals("Vine") && player.IsMoving() && !GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Play();
        }

        else if (tag.Equals("Vine") && !player.IsMoving() && GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Stop();
        }

        else if (tag.Equals("Tar") && player.IsMoving() && !GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Play();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other == null || !other.CompareTag("Player")) return;
        PlayerController player = other.GetComponent<PlayerController>();

        player.SameSpeed();

        if (tag.Equals("Vine") && GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Stop();
        }

        else if (tag.Equals("SlipperyMud"))
        {
            GetComponentInChildren<AudioSource>().Play();
        }

        if (tag.Equals("Tar") && GetComponentInChildren<AudioSource>().isPlaying)
        {
            GetComponentInChildren<AudioSource>().Stop();
        }
    }
}