using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerPrefs : MonoBehaviour {
    public int totaldeaths;
    public int totaljumps;
    public int totallevitates;
    public int levelcompleted;
    public int worldcompleted;
    public int timeskilledbyfire;
    public int timeskilledbywater;
    public int timeskilledbyrhino;
    public int timeskilledbycrocodile;
    public int timeskilledbylava;
    public int timeskilledbyswingingaxe;
    public int timeskilledbyspike;
    public int timeskilledbyfallinglog;
    public int timeskilledbybeartrap;
    public int timeskilledbysawblade;
    public float level1record;
    public float level2record;
    public float level3record;
    public float level5record;
    public float level6record;
    public float level7record;
    public float level9record;
    public float level10record;
    public float level11record;
    public float world1record;
    public float world2record;
    public float world3record;
    public float mastervolume;
    public float musicvolume;
    public float sfxvolume;
    
    //
    int wc;
    float wp;
    float volume;
    float sfxVolume;

	void Awake()
    {
        totaldeaths = PlayerPrefs.GetInt("Player Deaths");
        totaljumps = PlayerPrefs.GetInt("Total Times Jumped");
        totallevitates = PlayerPrefs.GetInt("Total Times Levitated");
        levelcompleted = PlayerPrefs.GetInt("World Progress");
        worldcompleted = PlayerPrefs.GetInt("World Completed");
        timeskilledbyfire= PlayerPrefs.GetInt("Times Killed By Fire");
        timeskilledbywater= PlayerPrefs.GetInt("Times Killed By Water");
        timeskilledbyrhino= PlayerPrefs.GetInt("Times Killed By Rhino");
        timeskilledbycrocodile= PlayerPrefs.GetInt("Times Killed By Crocodile");
        timeskilledbylava= PlayerPrefs.GetInt("Times Killed By Lava");
        timeskilledbyswingingaxe= PlayerPrefs.GetInt("Times Killed By Swinging Axe");
        timeskilledbyspike= PlayerPrefs.GetInt("Times Killed By Grass Spikes");
        timeskilledbyfallinglog= PlayerPrefs.GetInt("Times Killed By Falling Log");
        timeskilledbybeartrap= PlayerPrefs.GetInt("Times Killed By Bear Trap");
        timeskilledbysawblade= PlayerPrefs.GetInt("Times Killed By Saw Blade");
        level1record= PlayerPrefs.GetFloat("Level1 Record");
        level2record = PlayerPrefs.GetFloat("Level2 Record");
        level3record = PlayerPrefs.GetFloat("Level3 Record");
        level5record = PlayerPrefs.GetFloat("Level5 Record");
        level6record = PlayerPrefs.GetFloat("Level6 Record");
        level7record = PlayerPrefs.GetFloat("Level7 Record");
        level9record = PlayerPrefs.GetFloat("Level9 Record");
        level10record = PlayerPrefs.GetFloat("Level10 Record");
        level11record = PlayerPrefs.GetFloat("Level11 Record");
        world1record= PlayerPrefs.GetFloat("World1 Time Record");
        world2record = PlayerPrefs.GetFloat("World2 Time Record");
        world3record = PlayerPrefs.GetFloat("World3 Time Record");
        mastervolume = PlayerPrefs.GetFloat("Master Volume");
        musicvolume = PlayerPrefs.GetFloat("Music Volume");
        sfxvolume = PlayerPrefs.GetFloat("SFX Volume");
        //
        wc = PlayerPrefs.GetInt("World Completed");
        wp = PlayerPrefs.GetFloat("Music Volume");
        volume = PlayerPrefs.GetFloat("Master Volume");
        sfxVolume= PlayerPrefs.GetFloat("SFX Volume");

        if (wc == 0 && wp == 0.0f && volume == 0.0f&&sfxVolume==0.0f)
        {
            PlayerPrefs.SetInt("World Completed", 1);
            PlayerPrefs.SetFloat("Master Volume", 1.0f);
            PlayerPrefs.SetFloat("Music Volume", 1.0f);
            PlayerPrefs.SetFloat("SFX Volume", 1.0f);

        }
    }
}
