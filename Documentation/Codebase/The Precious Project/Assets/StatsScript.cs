using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour {
    public string world1Progress;
    public string world2Progress;
    public string world3Progress;
    public string world1Time;
    public string world2Time;
    public string world3Time;
    public int completedLevel;
    public float world1Record;
    public float world2Record;
    public float world3Record;
    Text statisticsToShow;
    // Use this for initialization
    void Start() {
        statisticsToShow = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        completedLevel = PlayerPrefs.GetInt("World Progress");
        world1Record = PlayerPrefs.GetFloat("World1 Time Record");
        world2Record = PlayerPrefs.GetFloat("World2 Time Record");
        world3Record = PlayerPrefs.GetFloat("World3 Time Record");
        if (completedLevel == 0)
        {
            world1Progress = "0%";
            world2Progress = "0%";
            world3Progress = "0%";
        }
        else if (completedLevel > 0 && completedLevel < 5)
        {
            world1Progress = (((float)(completedLevel - 1) / 4.0f) * 100.0f).ToString() + "%";
            world2Progress = "0%";
            world3Progress = "0%";
        }
        else if (completedLevel >= 5 && completedLevel < 9)
        {
            world1Progress = "100%";
            world2Progress = (((float)(completedLevel - 5) / 4.0f) * 100.0f).ToString() + "%";
            world3Progress = "0%";
        }
        else if (completedLevel >= 9 && completedLevel <=13)
        {
            world1Progress = "100%";
            world2Progress = "100%";
            world3Progress = (((float)(completedLevel - 9) / 4.0f) * 100.0f).ToString() + "%";
        }
        else if(completedLevel>13)
        {
            world1Progress = "100%";
            world2Progress = "100%";
            world3Progress = "100%";
        }
        
        if(world1Record==0)
        {
            world1Time = "";
            world2Time = "";
            world3Time = "";
        }
        else if(world2Record==0)
        {
            world1Time = world1Record.ToString("F2")+" seconds";
            world2Time = "";
            world3Time = "";
        }
        else if(world3Record==0)
        {
            world1Time = world1Record.ToString("F2") + " seconds";
            world2Time = world2Record.ToString("F2") + " seconds";
            world3Time = "";
        }
        else if(world1Record!=0&&world2Record!=0&&world3Record!=0)
        {
            world1Time = world1Record.ToString("F2") + " seconds";
            world2Time = world2Record.ToString("F2") + " seconds";
            world3Time = world3Record.ToString("F2") + " seconds";
        }
        
        statisticsToShow.text = "Total Deaths: " + PlayerPrefs.GetInt("Player Deaths") + "\n" +
            "Total Times Jumped: " + PlayerPrefs.GetInt("Total Times Jumped") + "\n" + "Total Times Levitated: " + PlayerPrefs.GetInt("Total Times Levitated") + "\n" +
            "World 1 Progress: " + world1Progress + "\n" + "World 2 Progress: " + world2Progress + "\n" + "World 3 Progress: " + world3Progress+"\n"+"World 1 Record: "+world1Time+"\n" + "World 2 Record: " + world2Time + "\n" + "World 3 Record: " + world3Time;
    }
}
