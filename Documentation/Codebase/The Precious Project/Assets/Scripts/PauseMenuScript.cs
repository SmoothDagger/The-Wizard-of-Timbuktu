using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuScript : MonoBehaviour {
    bool isPaused;
    bool buttonSelected;

    public EventSystem eventSystem;
    public GameObject pauseMenu;
    public GameObject eventObject;
    public GameObject selectedObject;
    public GameObject HUD;
    public GameObject panelPauseMenu;
    public bool canPauseOpen;

    // Use this for initialization
    void Start () {
        eventObject = GameObject.Find("EventSystem");
        eventSystem = eventObject.GetComponent<EventSystem>();
        pauseMenu = GameObject.Find("UI_Canvas_MainPauseMenu");
        HUD = GameObject.Find("InGameHUD");
        panelPauseMenu = GameObject.Find("Panel_PauseMenu");
        isPaused = false;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        canPauseOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPauseOpen == true)
        {
            if (Input.GetButtonDown("Cancel"))
            {

                eventSystem.SetSelectedGameObject(GameObject.Find("btn_ResumeGame"));

                if (!isPaused)
                {
                    HUD.GetComponent<Canvas>().enabled = false;
                    pauseMenu.GetComponent<Canvas>().enabled = true;
                    isPaused = true;
                    Time.timeScale = 0;
                }

                else
                {
                    pauseMenu.GetComponent<Canvas>().enabled = false;
                    isPaused = false;
                    Time.timeScale = 1;
                    HUD.GetComponent<Canvas>().enabled = true;
                    eventSystem.SetSelectedGameObject(pauseMenu);
                }
            }

            if (eventSystem.currentSelectedGameObject != null && Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.tag.Equals("ExitTheMenuAndStartGame"))
            {
                pauseMenu.GetComponent<Canvas>().enabled = false;
                isPaused = false;
                Time.timeScale = 1;
                HUD.GetComponent<Canvas>().enabled = true;
                eventSystem.SetSelectedGameObject(pauseMenu);
            }

            if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
            {
                eventSystem.SetSelectedGameObject(selectedObject);
                buttonSelected = true;
            }
        }
    }
    private void OnDisable()
    {
        buttonSelected = false;
    }

    public void unpause()
    {
        isPaused = false;
        pauseMenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        HUD.GetComponent<Canvas>().enabled = true;
        eventSystem.SetSelectedGameObject(pauseMenu);
    }
}