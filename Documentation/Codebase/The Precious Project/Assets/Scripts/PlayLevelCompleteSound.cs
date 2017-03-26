using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelCompleteSound : MonoBehaviour {
    GameObject levelCompleteSound;

    void Start()
    {
        levelCompleteSound = GameObject.Find("LevelCompleteSound");
        DontDestroyOnLoad(levelCompleteSound);
    }
}
