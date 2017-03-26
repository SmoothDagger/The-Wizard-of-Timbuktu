using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    float playersTimeScale;
    public bool isPaused;
    bool buttonSelected;
    bool isSoundPaused;
    public bool canPauseOpen;
    float timescalePause;
    bool mobile;

    EventSystem eventSystem;
    
    GameObject pauseMenu;
    GameObject HUD;
    public GameObject levelEndHudObject;
    public GameObject world1EndHudObject;
    public GameObject world2EndHudObject;
    public GameObject world3EndHudObject;

    GameObject selectedObject;
    GameObject levelFinish;
    GameObject player;
    public GameObject audioManager;
    public GameObject settingsPanel;
    public GameObject pauseMenuPanel;
    public GameObject mobileControls;

    GameObject timeStopSoundSource;

    //Ge's Update
    
    int currentLevel;
    int nextLevel;
    int bestRecord;
    int completedWorld;

    GameObject timestopPanel;
    Color colorForPanel;

    // Use this for initialization
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            mobile = true;
            mobileControls = GameObject.Find("Mobile Platform Controls");
        }
        isPaused = false;
        canPauseOpen = true;

        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        pauseMenu = GameObject.Find("UI_Canvas_MainPauseMenu");

        HUD = GameObject.Find("UI_Canvas_InGameHUD");

        levelEndHudObject = GameObject.Find("UI_Canvas_LevelEnd");
        world1EndHudObject = GameObject.Find("UI_Canvas_World1End");
        world2EndHudObject = GameObject.Find("UI_Canvas_World2End");
        world3EndHudObject = GameObject.Find("UI_Canvas_World3End");

        levelFinish = GameObject.FindGameObjectWithTag("Finish");

        player = GameObject.FindGameObjectWithTag("Player");

        settingsPanel = GameObject.Find("Panel_GameSettings");

        pauseMenuPanel = GameObject.Find("Panel_PauseMenu");
        currentLevel = SceneManager.GetActiveScene().buildIndex - 5;
        nextLevel = currentLevel + 1;
        bestRecord= PlayerPrefs.GetInt("World Progress");
        completedWorld = PlayerPrefs.GetInt("World Completed");

        pauseMenu.SetActive(false);
        settingsPanel.SetActive(false);
        levelEndHudObject.SetActive(false);
        world1EndHudObject.SetActive(false);
        world2EndHudObject.SetActive(false);
        world3EndHudObject.SetActive(false);

        if (FindObjectOfType<AudioManagerScript>()) return;
        else Instantiate(audioManager, transform.position, transform.rotation);

        timeStopSoundSource = GameObject.Find("TimeStopSoundSource");

        timestopPanel = GameObject.Find("Timestop Panel");
        timescalePause = 0.0000001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer&&currentLevel!=4&&currentLevel!=8 && currentLevel != 12)
        {
            HUD.SetActive(false);
            levelEndHudObject.SetActive(true);
            world1EndHudObject.SetActive(false);
            world2EndHudObject.SetActive(false);
            world3EndHudObject.SetActive(false);

            Time.timeScale = timescalePause;
            player.GetComponent<PlayerController>().controllable = false;
            canPauseOpen = false;
            
            if (nextLevel > bestRecord)
            {
                bestRecord = nextLevel;
                PlayerPrefs.SetInt("World Progress", bestRecord);
            }
           
        }
        if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel==4)
        {
            HUD.SetActive(false);
            world1EndHudObject.SetActive(true);
            world2EndHudObject.SetActive(false);
            world3EndHudObject.SetActive(false);
            levelEndHudObject.SetActive(false);
            Time.timeScale = timescalePause;
            player.GetComponent<PlayerController>().controllable = false;
            canPauseOpen = false;

            
            if (completedWorld == 1)
            {
                completedWorld++;
                PlayerPrefs.SetInt("World Completed", completedWorld);
            }
            if (nextLevel > bestRecord)
            {
                bestRecord = nextLevel;
                PlayerPrefs.SetInt("World Progress", bestRecord);
            } 
        }
        if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel == 8)
        {
            HUD.SetActive(false);
            world1EndHudObject.SetActive(false);
            world3EndHudObject.SetActive(false);
            levelEndHudObject.SetActive(false);
            world2EndHudObject.SetActive(true);
            Time.timeScale = timescalePause;
            player.GetComponent<PlayerController>().controllable = false;
            canPauseOpen = false;
            if (completedWorld == 2)
            {
                completedWorld++;
                PlayerPrefs.SetInt("World Completed", completedWorld);
            }
            if (nextLevel > bestRecord)
            {
                bestRecord = nextLevel;
                PlayerPrefs.SetInt("World Progress", bestRecord);
            }
        }
        if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel == 12)
        {
            HUD.SetActive(false);
            world1EndHudObject.SetActive(false);
            levelEndHudObject.SetActive(false);
            world2EndHudObject.SetActive(false);
            world3EndHudObject.SetActive(true);
            Time.timeScale = timescalePause;
            player.GetComponent<PlayerController>().controllable = false;
            canPauseOpen = false;
            if (completedWorld == 3)
            {
                completedWorld++;
                PlayerPrefs.SetInt("World Completed", completedWorld);
            }
            if (nextLevel > bestRecord)
            {
                bestRecord = nextLevel;
                PlayerPrefs.SetInt("World Progress", bestRecord);
            }
        }

        if (canPauseOpen)
        {
            if (Input.GetButtonDown("Cancel"))
            {

                if (isPaused && settingsPanel.activeInHierarchy)
                {
                    settingsPanel.SetActive(false);
                    pauseMenuPanel.SetActive(true);
                    selectedObject = GameObject.Find("btn_ResumeGame");
                    eventSystem.SetSelectedGameObject(selectedObject);
                }

                else if (isPaused == false) { pause(); }

                else { unpause(); }
            }

            else if (eventSystem.currentSelectedGameObject != null && Input.GetButtonDown("Submit") && eventSystem.currentSelectedGameObject.tag.Equals("ExitTheMenuAndStartGame")) {
                unpause();
            }

            else if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
            {
                eventSystem.SetSelectedGameObject(selectedObject);
                buttonSelected = true;
            }
        }

        else
            Time.timeScale = timescalePause;

        if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel >= 1 && currentLevel <= 4)
            PlayerPrefs.SetInt("Last World Played", 1);

        else if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel >= 5 && currentLevel <= 8)
            PlayerPrefs.SetInt("Last World Played", 2);

        else if (levelFinish.GetComponent<InvokeLevelEndHUD>().collidedWithPlayer && currentLevel >= 9 && currentLevel <= 12)
            PlayerPrefs.SetInt("Last World Played", 3);
    }
    private void OnDisable()
    {
        buttonSelected = false;
    }

    public void unpause()
    {
        player.GetComponent<PlayerController>().controllable = true;
        timeStopSoundSource = GameObject.Find("TimeStopSoundSource");
        HUD.SetActive(true);
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        if (isSoundPaused)
        {
            timeStopSoundSource.GetComponent<AudioSource>().UnPause();
            isSoundPaused = false;
        }
        player.GetComponent<PlayerController>().setLocalTimeScale(playersTimeScale);
        timestopPanel.SetActive(true);
        if (mobile)
            mobileControls.SetActive(true);
    }

    public void pause()
    {
        player.GetComponent<PlayerController>().controllable = false;
        timeStopSoundSource = GameObject.Find("TimeStopSoundSource");
        HUD.SetActive(false);
        isPaused = true;
        Time.timeScale = timescalePause;
        pauseMenu.SetActive(true);
        selectedObject = GameObject.Find("btn_ResumeGame");
        eventSystem.SetSelectedGameObject(selectedObject);
        if (timeStopSoundSource != null && isPaused && timeStopSoundSource.GetComponent<AudioSource>().isPlaying)
        {
            timeStopSoundSource.GetComponent<AudioSource>().Pause();
            isSoundPaused = true;
        }
        playersTimeScale = player.GetComponent<PlayerController>().localTimeScale();
        timestopPanel.SetActive(false);
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }
}