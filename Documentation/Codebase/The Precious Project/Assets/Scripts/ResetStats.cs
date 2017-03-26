using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStats : MonoBehaviour {
    public void ResetStatsForPlayer()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("World Progress", 0);
        PlayerPrefs.SetInt("Player Deaths", 0);
        PlayerPrefs.SetInt("World Completed", 1);
        PlayerPrefs.SetFloat("Master Volume", 1.0f);
        PlayerPrefs.SetFloat("Music Volume", 1.0f);
        PlayerPrefs.SetFloat("SFX Volume", 1.0f);
    }
}
