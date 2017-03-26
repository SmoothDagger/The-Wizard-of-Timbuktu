using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField]
    int sceneToLoad;
    //Load different scenes based on their index
    public void InvokeLoadingScreen()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        PlayerPrefs.SetInt("Scene To Load", sceneToLoad);
        SceneManager.LoadScene(1);
    }
}
