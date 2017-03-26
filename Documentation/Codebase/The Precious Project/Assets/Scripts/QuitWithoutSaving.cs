using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitWithoutSaving : MonoBehaviour {
    
	// Use this for initialization
    public void DeleteOnQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Player Deaths",gameObject.GetComponentInParent<ReadPlayerPrefs>().totaldeaths);
        PlayerPrefs.SetInt("Total Times Jumped", gameObject.GetComponentInParent<ReadPlayerPrefs>().totaljumps);
        PlayerPrefs.SetInt("Total Times Levitated", gameObject.GetComponentInParent<ReadPlayerPrefs>().totallevitates);
        PlayerPrefs.SetInt("World Progress", gameObject.GetComponentInParent<ReadPlayerPrefs>().levelcompleted);
        PlayerPrefs.SetInt("World Completed", gameObject.GetComponentInParent<ReadPlayerPrefs>().worldcompleted);
        PlayerPrefs.SetInt("Times Killed By Fire", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbyfire);
        PlayerPrefs.SetInt("Times Killed By Water", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbywater);
        PlayerPrefs.SetInt("Times Killed By Rhino", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbyrhino);
        PlayerPrefs.SetInt("Times Killed By Crocodile", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbycrocodile);
        PlayerPrefs.SetInt("Times Killed By Lava", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbylava);
        PlayerPrefs.SetInt("Times Killed By Swinging Axe", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbyswingingaxe);
        PlayerPrefs.SetInt("Times Killed By Grass Spikes", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbyspike);
        PlayerPrefs.SetInt("Times Killed By Falling Log", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbyfallinglog);
        PlayerPrefs.SetInt("Times Killed By Bear Trap", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbybeartrap);
        PlayerPrefs.SetInt("Times Killed By Saw Blade", gameObject.GetComponentInParent<ReadPlayerPrefs>().timeskilledbysawblade);
        PlayerPrefs.SetFloat("Level1 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level1record);
        PlayerPrefs.SetFloat("Level2 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level2record);
        PlayerPrefs.SetFloat("Level3 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level3record);
        PlayerPrefs.SetFloat("Level5 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level5record);
        PlayerPrefs.SetFloat("Level6 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level6record);
        PlayerPrefs.SetFloat("Level7 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level7record);
        PlayerPrefs.SetFloat("Level9 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level9record);
        PlayerPrefs.SetFloat("Level10 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level10record);
        PlayerPrefs.SetFloat("Level11 Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().level11record);
        PlayerPrefs.SetFloat("World1 Time Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().world1record);
        PlayerPrefs.SetFloat("World2 Time Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().world2record);
        PlayerPrefs.SetFloat("World3 Time Record", gameObject.GetComponentInParent<ReadPlayerPrefs>().world3record);
        PlayerPrefs.SetFloat("Master Volume", gameObject.GetComponentInParent<ReadPlayerPrefs>().mastervolume);
        PlayerPrefs.SetFloat("Music Volume", gameObject.GetComponentInParent<ReadPlayerPrefs>().musicvolume);
        PlayerPrefs.SetFloat("SFX Volume", gameObject.GetComponentInParent<ReadPlayerPrefs>().sfxvolume);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
