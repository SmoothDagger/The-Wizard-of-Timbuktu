using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    GameObject player;
    GameObject inGameHUD;
    Text timerText;
    Color color;
    float time;
    float elapsedTimer;
    float blinkSpeed;
    public float levelCompletionTime;
    public float checkpointTime;
    bool stopTime;
    int checkpointCount;

    public bool Paused { get; set; }

	// Use this for initialization
	void Start () {
        //time = getStartTime(); 
        player = GameObject.Find("Player");
        inGameHUD = GameObject.Find("UI_Canvas_InGameHUD");
        timerText = inGameHUD.GetComponentInChildren<Text>();
        color = timerText.color;
        time = 60.0f;
        blinkSpeed = 0.02575f;
        checkpointTime = 0.0f;
        levelCompletionTime = 0.0f;

        timerText.text = Time.timeSinceLevelLoad.ToString();
        checkpointCount = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!Paused)
            time -= Time.deltaTime;
        timerText.text = time.ToString("F2");

        if (time <= 45.0f && time >= 44.40f) { color.a -= blinkSpeed; }
        else if (time < 44.40f && time > 43.80f) { color.a += blinkSpeed; }

        if (time <= 30.0f && time >= 29.40f) { color.a -= blinkSpeed; }
        else if (time < 29.40f && time > 28.80f) { color.a += blinkSpeed; }

        if (time <= 15.0f && time >= 14.40f) { color.a -= blinkSpeed; }
        else if (time < 14.40f && time > 13.80f) { color.a += blinkSpeed; }

        if (time < 11.0f && time > 10.5f) { blinkSpeed += .00075f; }

        if (time < 10.0f)
        {
            if ((int)(time * 100f) % 100 >= 60) { color.a -= blinkSpeed; }

            else if ((int)(time * 100f) % 100 < 60 && (int)(time * 100f) % 100 >= 20) { color.a += blinkSpeed; }
        }

        if (time <= 0.0f)
        {
            ResetTime(true);
            player.GetComponent<PlayerController>().Die();
        }

        timerText.color = color;

        checkpointTime += Time.deltaTime;
	}

    public void ResetTime(bool _didPlayerDie) {
        if (_didPlayerDie)
        {
            checkpointTime = 0.0f;
        }
        else
        {
            levelCompletionTime += checkpointTime;
            checkpointCount++;
        }
        time = 60.0f;
        timerText.text = time.ToString("F2");
        color.a = 1.0f;
        blinkSpeed = 0.02575f;
    }

    public float GetLevelCompletionTime()
    {
        return levelCompletionTime;
    }

    public int GetCheckpointCount()
    {
        return checkpointCount;
    }
}
