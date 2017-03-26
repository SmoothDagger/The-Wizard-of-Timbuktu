using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class LevelLoader : MonoBehaviour
{
    public static GameObject confirmButton;
    [SerializeField]
    GUIStyle mystyle;
    [SerializeField]
    int levelToLoad;
    [SerializeField]
    int sceneToLoad;
    private string loadPrompt;
    private bool inRange;
    private bool canLoadLevel;
    private int completedLevel;
    bool mobile;
    // Use this for initialization
    private void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            confirmButton = GameObject.Find("Confirm Button");
            mobile = true;
        }
        else
            mobile = false;

    }
    void Start()
    {
        if (mobile)
            if (confirmButton.activeInHierarchy)
                confirmButton.SetActive(false);
        completedLevel = PlayerPrefs.GetInt("World Progress");
        canLoadLevel = levelToLoad <= completedLevel ? true : false;
        if (canLoadLevel == false)
            gameObject.SetActive(false);
        mystyle.font = (Font)Resources.Load("PikiPiki");
        mystyle.normal.textColor = Color.blue;
    }
    void OnTriggerStay(Collider other)
    {
        inRange = true;
        inRange = true;
        if (mobile)
        {
            loadPrompt = "Press button to enter the level";
            confirmButton.SetActive(true);
        }
        if (!mobile)
            loadPrompt = "Press [E] to enter the Level ";
    }
    void OnTriggerExit()
    {
        inRange = false;
        loadPrompt = "";
        if (mobile == true)
            confirmButton.SetActive(false);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.1f, 0, Screen.width * 0.9f, Screen.height * 0.2f), loadPrompt, mystyle);
    }
    // Update is called once per frame
    void Update()
    {
        if (canLoadLevel == true && inRange == true && CrossPlatformInputManager.GetButtonDown("Confirm"))
        {
            PlayerPrefs.SetInt("Scene To Load", sceneToLoad);
            SceneManager.LoadScene(1);
        }
    }
}
