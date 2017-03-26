using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumePauseMenu : MonoBehaviour {
    GameObject musicVolumeSlider;
    float musicVolumeValue;
    // Use this for initialization
    void Start()
    {
        musicVolumeSlider = GameObject.Find("Music Volume Value");
        musicVolumeValue = PlayerPrefs.GetFloat("Music Volume");
        musicVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music Volume");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        musicVolumeValue = musicVolumeSlider.GetComponent<Slider>().value;
        musicVolumeSlider.GetComponent<Slider>().value = musicVolumeValue;
    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat("Music Volume", musicVolumeValue);
    }
}
