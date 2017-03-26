using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocker : MonoBehaviour {
    [SerializeField]
    GUIStyle mystyle;
    [SerializeField]
    int currentLevel;
    private bool shouldShowLocker;
    private string loadPrompt;
    void Start () {
        shouldShowLocker = currentLevel > PlayerPrefs.GetInt("World Progress") ? true : false;
        if (shouldShowLocker == true)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
        mystyle.font = (Font)Resources.Load("PikiPiki");
        mystyle.normal.textColor = Color.blue;
    }
    void OnTriggerStay(Collider other)
    {
        loadPrompt = "Sorry, you don't have the access to this level.";

    }
    void OnTriggerExit()
    {
        loadPrompt = "";
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width*0.1f, 0, Screen.width*0.9f, Screen.height*0.2f), loadPrompt, mystyle);
    }

}
