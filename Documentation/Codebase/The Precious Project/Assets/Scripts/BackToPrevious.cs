using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class BackToPrevious : MonoBehaviour
{
    static GameObject confirmButton;
    [SerializeField]
    GUIStyle mystyle;
    [SerializeField]
    int sceneToLoad;
    private string loadPrompt;
    private bool inRange;
    bool mobile;
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
        mystyle.font = (Font)Resources.Load("PikiPiki");
        mystyle.normal.textColor = Color.blue;
        if (mobile == true)
            confirmButton.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        inRange = true;
        if (mobile)
        {
           loadPrompt = "Press button to go back";
           confirmButton.SetActive(true);
        }
        if (!mobile)
           loadPrompt = "Press [E] to go back";
    }
    void OnTriggerExit()
    {
        inRange = false;
        loadPrompt = "";
        if (mobile)
            confirmButton.SetActive(false);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.1f, 0, Screen.width * 0.9f, Screen.height * 0.2f), loadPrompt, mystyle);
    }
    // Update is called once per frame
    void Update()
    {

        if (inRange == true && CrossPlatformInputManager.GetButtonDown("Confirm"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                PlayerPrefs.SetInt("Last World Played", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.SetInt("Last World Played", 2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                PlayerPrefs.SetInt("Last World Played", 3);
            }

            PlayerPrefs.SetInt("Scene To Load", sceneToLoad);
            SceneManager.LoadScene(1);
        }
    }
}
