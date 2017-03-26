using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButtonScript : MonoBehaviour {
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("UI_Canvas_MainPauseMenu");
    }
	// Update is called once per frame
	public void TriggerUnpause()
    {
        pauseMenu.SetActive(false);
    }
}
