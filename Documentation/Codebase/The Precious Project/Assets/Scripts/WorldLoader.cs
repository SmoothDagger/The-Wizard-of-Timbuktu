using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//to add
using UnityStandardAssets.CrossPlatformInput;
//

public class WorldLoader : MonoBehaviour
{
    //to add
    public GameObject confirmButton;
    //
    [SerializeField]
    GUIStyle mystyle;
    [SerializeField]
    int worldToLoad;
    [SerializeField]
    int sceneToLoad;
    private string loadPrompt;
    private string text;
    private bool inRange;
    private bool canEnterWorld;
    private int completedWorld;
    private int level1Access;
    //to add
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
    //
    void Start()
    {
        if (mobile)
            if (confirmButton.activeInHierarchy)
                confirmButton.SetActive(false);
        completedWorld = PlayerPrefs.GetInt("World Completed");
        canEnterWorld = worldToLoad <= completedWorld ? true : false;
        level1Access = PlayerPrefs.GetInt("World Progress");
        if (!canEnterWorld)
            gameObject.SetActive(false);
        mystyle.font = (Font)Resources.Load("PikiPiki");
        mystyle.normal.textColor = Color.blue;
    }
    void OnTriggerStay(Collider other)
    {
        inRange = true;
        //to add
        if (mobile)
        {
            confirmButton.SetActive(true);
            loadPrompt = "Press button to enter World " + worldToLoad.ToString();
        }
        if (!mobile)
            loadPrompt = "Press [E] to enter World " + worldToLoad.ToString ();
        //
    }
    void OnTriggerExit()
    {
        inRange = false;
        loadPrompt = "";
        //to add
        if (mobile)
            confirmButton.SetActive(false);
        //
    }
    void OnGUI()
    {
        //to add
            GUI.Label(new Rect(Screen.width * 0.1f, 0, Screen.width * 0.9f, Screen.height * 0.2f), loadPrompt, mystyle);
        //
    }
    void FixedUpdate()
    {
        //change input to Crossplatforminputmanager
        if (canEnterWorld == true && inRange == true && CrossPlatformInputManager.GetButtonDown("Confirm"))
        {
            if (level1Access == 0)
                PlayerPrefs.SetInt("World Progress", 1);
            PlayerPrefs.SetInt("Scene To Load", sceneToLoad);
            SceneManager.LoadScene(1);
        }
    }
}


