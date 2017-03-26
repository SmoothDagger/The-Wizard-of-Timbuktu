using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxVolumeSettings : MonoBehaviour {
    GameObject sfxVolumeSlider;
    float sfxVolumeValue;
    // Use this for initialization
    void Start () {
        sfxVolumeValue = PlayerPrefs.GetFloat("SFX Volume");
        sfxVolumeSlider = GameObject.Find("SFX Volume Slider");
        sfxVolumeSlider.GetComponent<Slider>().value = sfxVolumeValue;
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        sfxVolumeSlider.GetComponent<Slider>().value = sfxVolumeValue;
    }

    public void OnValueChanged()
    {
        sfxVolumeValue = sfxVolumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("SFX Volume", sfxVolumeValue);
    }
}
