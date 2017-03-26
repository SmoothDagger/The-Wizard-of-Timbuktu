using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour {

    public AudioClip[] BackgroundMusic;
    public GameObject[] SoundEffects;
    AudioSource audioSource;
    int currentScene;
    // Use this for initialization
    void Start() {
        AudioListener.volume = PlayerPrefs.GetFloat("Master Volume");
        currentScene = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("Music Volume");
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<AudioManagerScript>().Length > 1)
            Destroy(gameObject);

        SoundEffects = GameObject.FindGameObjectsWithTag("SoundEffect");

        PlaySoundBackgroundMusic(PlayerPrefs.GetInt("Last World Played"), true);
    }
	// Update is called once per frame
	void Update () {
        audioSource.volume = PlayerPrefs.GetFloat("Music Volume");
        if (currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            PlaySoundBackgroundMusic(currentScene, false);
            currentScene = SceneManager.GetActiveScene().buildIndex;
            SoundEffects = GameObject.FindGameObjectsWithTag("SoundEffect");
        }

        if (SoundEffects.Length >= 1)
        {
            SoundEffects = GameObject.FindGameObjectsWithTag("SoundEffect");
            foreach (GameObject sfx in SoundEffects)
            {
                sfx.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SFX Volume");
            }
        }
    }

    public void PlaySoundBackgroundMusic(int worldNumber, bool firstTimeSoundPlaying)
    {
        int _clipNumber;

        if (firstTimeSoundPlaying && worldNumber >= 1 && worldNumber <= 3)
        {
            if (1 == worldNumber)
            {
                audioSource.clip = BackgroundMusic[0];
                audioSource.Play();
            }
            else
            {
                _clipNumber = worldNumber - 1;
                audioSource.clip = BackgroundMusic[_clipNumber];
                audioSource.Play();
            }
        }

        else
        {
            _clipNumber = SceneManager.GetActiveScene().buildIndex;

            switch (_clipNumber)
            {
                case 3:
                case 6:
                case 7:
                case 8:
                case 9:
                    if (CheckIfAudioShouldSwitch(0))
                    {
                        audioSource.Stop();
                        audioSource.clip = BackgroundMusic[0];
                        audioSource.Play();
                    }
                    break;
                case 4:
                case 10:
                case 11:
                case 12:
                case 13:
                    if (CheckIfAudioShouldSwitch(1))
                    {
                        audioSource.Stop();
                        audioSource.clip = BackgroundMusic[1];
                        audioSource.Play();
                    }
                    break;
                case 5:
                case 14:
                case 15:
                case 16:
                case 17:
                    if (CheckIfAudioShouldSwitch(2))
                    {
                        audioSource.Stop();
                        audioSource.clip = BackgroundMusic[2];
                        audioSource.Play();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    bool CheckIfAudioShouldSwitch(int clipNum)
    {
        if (audioSource.clip.name == BackgroundMusic[clipNum].name)
            return false;

        else return true;
    }
}