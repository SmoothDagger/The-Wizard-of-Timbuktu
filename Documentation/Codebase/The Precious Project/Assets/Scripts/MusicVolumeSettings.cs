using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSettings : MonoBehaviour {
    GameObject musicVolumeSlider;
    float musicVolumeValue;
    // Use this for initialization
    void Start () {
        musicVolumeSlider = GameObject.Find("Music Volume Slider");
        musicVolumeValue = PlayerPrefs.GetFloat("Music Volume");
        musicVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music Volume");
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        musicVolumeSlider.GetComponent<Slider>().value = musicVolumeValue;
    }
    public void OnValueChanged()
    {
        musicVolumeValue = musicVolumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Music Volume", musicVolumeValue);
    }
}
