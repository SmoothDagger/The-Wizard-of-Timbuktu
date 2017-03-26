using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowBestRecordTime : MonoBehaviour {
    [SerializeField]
    Text messageBox;
    private int currentLevel;
    public float recordOfLevel;
    public float levelpassedTime;
	// Use this for initialization
	void Start () {
		currentLevel= SceneManager.GetActiveScene().buildIndex - 5;
        levelpassedTime = PlayerPrefs.GetFloat("Level" + currentLevel.ToString() + " Passed Time");
        recordOfLevel = PlayerPrefs.GetFloat("Level" + currentLevel.ToString() + " Record");
    }
	
	// Update is called once per frame
	void Update () {
        levelpassedTime = PlayerPrefs.GetFloat("Level" + currentLevel.ToString() + " Passed Time");
        recordOfLevel = PlayerPrefs.GetFloat("Level" + currentLevel.ToString() + " Record");
        if (recordOfLevel == 0.0f)
        {
            recordOfLevel = levelpassedTime;
            PlayerPrefs.SetFloat("Level" + currentLevel.ToString() + " Record", recordOfLevel);
        }
        else if (levelpassedTime <= recordOfLevel)
        {
            recordOfLevel = levelpassedTime;
            PlayerPrefs.SetFloat("Level" + currentLevel.ToString() + " Record", recordOfLevel);
        }
        messageBox.text = "Your best record is: " + recordOfLevel.ToString("F2") + " seconds";
    }
}
