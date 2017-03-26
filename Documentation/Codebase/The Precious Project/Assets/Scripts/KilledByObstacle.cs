using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilledByObstacle : MonoBehaviour
{
    public GameObject player;
    public GameObject deathNotification;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void ResumeGame()
    {
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().isKilledByFire = false;
        player.GetComponent<PlayerController>().isKilledByWater = false;
        player.GetComponent<PlayerController>().isKilledByRhino = false;
        player.GetComponent<PlayerController>().isKilledByCrocodile = false;
        player.GetComponent<PlayerController>().isKilledByLava = false;
        player.GetComponent<PlayerController>().isKilledBySwingingAxe = false;
        player.GetComponent<PlayerController>().isKilledByGrassSpikes = false;
        player.GetComponent<PlayerController>().isKilledByFallingLog = false;
        player.GetComponent<PlayerController>().isKilledByBearTrap = false;
        player.GetComponent<PlayerController>().isKilledBySawBlade = false;
        deathNotification.SetActive(false);
        player.GetComponent<Timer>().ResetTime(true);
        player.GetComponent<PlayerController>().sceneMangerObject.transform.GetChild(0).gameObject.SetActive(true);
        player.GetComponent<PlayerController>().sceneMangerObject.GetComponent<SceneManagerScript>().canPauseOpen = true;
        player.GetComponent<PlayerController>().controllable = true;
    }
}

