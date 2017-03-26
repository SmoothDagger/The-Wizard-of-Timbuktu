using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowLevelProgress : MonoBehaviour {

    Text levelprogress;
    int levelrecord;
    // Use this for initialization
    void Start () {
        levelprogress = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        levelrecord = PlayerPrefs.GetInt("World Progress", levelrecord);
        levelprogress.text = "Game Progress: " + ((levelrecord*100)/4).ToString() + "%";
    }
}
