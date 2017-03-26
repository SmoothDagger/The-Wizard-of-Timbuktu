using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevelAvailablity : MonoBehaviour {
   
    [SerializeField]
    int currentlevelindex;
    int levelpassed;
	void Start () {
        
        levelpassed = PlayerPrefs.GetInt("World Progress", levelpassed);
        
	}
	
	// Update is called once per frame
	void Update () {
        if (currentlevelindex > levelpassed)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
