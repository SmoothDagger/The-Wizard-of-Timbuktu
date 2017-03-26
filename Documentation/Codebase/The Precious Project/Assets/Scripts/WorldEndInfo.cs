using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldEndInfo : MonoBehaviour
{
    [SerializeField]
    Text message;
    private int currentlevel;
    private float worldPassedTime;
    private float timer;
    private float currentLevelTime;
    Timer timerInstance;
    // Use this for initialization
    void Start()
    {
        currentlevel = SceneManager.GetActiveScene().buildIndex - 5;
        timerInstance = GameObject.Find("Player").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlevel == 4)
        {
            worldPassedTime = PlayerPrefs.GetFloat("Level1 Passed Time") + PlayerPrefs.GetFloat("Level2 Passed Time") + PlayerPrefs.GetFloat("Level3 Passed Time") + timerInstance.GetLevelCompletionTime();
            message.text = "You passed the Savannah world in " + worldPassedTime.ToString("F2") + " seconds";
            PlayerPrefs.SetFloat("World1 Passed Time", worldPassedTime);
        }
        else if (currentlevel == 8)
        {
            worldPassedTime = PlayerPrefs.GetFloat("Level5 Passed Time") + PlayerPrefs.GetFloat("Level6 Passed Time") + PlayerPrefs.GetFloat("Level7 Passed Time") + timerInstance.GetLevelCompletionTime();
            message.text = "You passed the Lava world in " + worldPassedTime.ToString("F2") + " seconds";
            PlayerPrefs.SetFloat("World2 Passed Time", worldPassedTime);
        }
        else if (currentlevel == 12)
        {
            worldPassedTime = PlayerPrefs.GetFloat("Level9 Passed Time") + PlayerPrefs.GetFloat("Level10 Passed Time") + PlayerPrefs.GetFloat("Level11 Passed Time") + timerInstance.GetLevelCompletionTime();
            message.text = "You passed the Jungle world in " + worldPassedTime.ToString("F2") + " seconds";
            PlayerPrefs.SetFloat("World3 Passed Time", worldPassedTime);
        }
    }
}
