using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    // Attached to Obstacles - Player object must have the "Player" tag
    public class InvokeLevelEndHUD : MonoBehaviour
    {
    public bool collidedWithPlayer;
    public new AudioSource audio;

    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter(Collider objecCollider)
    {
        if (objecCollider.gameObject.tag == "Player")
        {
            collidedWithPlayer = true;
            objecCollider.GetComponent<Timer>().ResetTime(false);
            audio.Play();
        }
    }
}