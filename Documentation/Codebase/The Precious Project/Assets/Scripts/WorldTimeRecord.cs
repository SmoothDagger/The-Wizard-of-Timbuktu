using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldTimeRecord : MonoBehaviour {
    [SerializeField]
    Text messageBox;
    private int currentLevel;
    private float currentTime;
    private float recordTime;
    // Use this for initialization
    void Start () {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 5;
    }
	
	// Update is called once per frame
	void Update () {
        if (currentLevel == 4)
        {
            currentTime = PlayerPrefs.GetFloat("World1 Passed Time");
            recordTime = PlayerPrefs.GetFloat("World1 Time Record");
            if (recordTime == 0)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World1 Time Record", recordTime);
            }
            else if(currentTime<=recordTime)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World1 Time Record", recordTime);
            }
            messageBox.text = " Your record of this world is " + recordTime.ToString("F2") + " Seconds";
        }
        else if (currentLevel == 8)
        {
            currentTime = PlayerPrefs.GetFloat("World2 Passed Time");
            recordTime = PlayerPrefs.GetFloat("World2 Time Record");
            if (recordTime == 0)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World2 Time Record", recordTime);
            }
            else if (currentTime <= recordTime)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World2 Time Record", recordTime);
            }
            messageBox.text = " Your record of this world is " + recordTime.ToString("F2") + " Seconds";
        }
        else if (currentLevel == 12)
        {
            currentTime = PlayerPrefs.GetFloat("World3 Passed Time");
            recordTime = PlayerPrefs.GetFloat("World3 Time Record");
            if (recordTime == 0)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World3 Time Record", recordTime);
            }
            else if (currentTime <= recordTime)
            {
                recordTime = currentTime;
                PlayerPrefs.SetFloat("World3 Time Record", recordTime);
            }
            messageBox.text = " Your record of this world is " + recordTime.ToString("F2") + " Seconds";
        }
    }
}
