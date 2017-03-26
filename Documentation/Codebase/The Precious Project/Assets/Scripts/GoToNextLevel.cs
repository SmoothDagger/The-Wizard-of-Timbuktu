using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

	public void NavigateToNextLevel()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 6)
            SceneManager.LoadScene(0);
        else if (currentScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(currentScene + 1);
    }
}
