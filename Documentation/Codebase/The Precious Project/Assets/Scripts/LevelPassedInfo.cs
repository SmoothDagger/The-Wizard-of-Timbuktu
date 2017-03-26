using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelPassedInfo : MonoBehaviour {
    [SerializeField]
    Text message;
    private int currentlevel;
    private float timer;
    Timer timerInstance;

    // Use this for initialization
    void Start () {
        currentlevel = SceneManager.GetActiveScene().buildIndex - 5;
        timerInstance = GameObject.Find("Player").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update () {
        message.text = "You passed level " + currentlevel.ToString() + " in " + timerInstance.GetLevelCompletionTime().ToString("F2") + " seconds";
        PlayerPrefs.SetFloat("Level" + currentlevel.ToString() + " Passed Time", timerInstance.GetLevelCompletionTime());
    }
}
