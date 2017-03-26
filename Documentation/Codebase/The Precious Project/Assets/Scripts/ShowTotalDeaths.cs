using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTotalDeaths : MonoBehaviour {
    Text deathLabel;
    int deathrecord;
	// Use this for initialization
	void Start () {
        deathLabel = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        deathrecord = PlayerPrefs.GetInt("Player Deaths", deathrecord);
        deathLabel.text = "Total Deaths: " + deathrecord.ToString();
    }
}
