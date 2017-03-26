using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingText : MonoBehaviour {
    private int sceneToLoad;
    public GameObject loadingText;
    public GameObject progressBar;
    private AsyncOperation async;
	// Use this for initialization
	void Start () {
        loadingText = GameObject.Find("Loading Text");
        progressBar= GameObject.Find("ProgressBar");
        sceneToLoad = PlayerPrefs.GetInt("Scene To Load");
        if (Time.timeScale != 1)
            Time.timeScale = 1;
        progressBar.GetComponent<Image>().fillAmount = 0;
        loadingText.GetComponent<Text>().text = "Loading . . .";
        
        StartCoroutine(LoadNewScene());
    }
    
    IEnumerator LoadNewScene()
    {
        if (sceneToLoad >= 0 && sceneToLoad <= 6)
            yield return new WaitForSeconds(2.0f);
        async = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!async.isDone)
        {
            progressBar.GetComponent<Image>().fillAmount = async.progress;
            if (async.progress == 0.9f)
            {
                progressBar.GetComponent<Image>().fillAmount = 1;
                loadingText.GetComponent<Text>().text = "Done";
            }
            yield return null;
        }
    }

}
