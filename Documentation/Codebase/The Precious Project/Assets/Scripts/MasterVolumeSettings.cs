using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSettings : MonoBehaviour {
    public GameObject masterVolumeSlider;

    float masterVolumeValue;
    // Use this for initialization
    void Start () {
        masterVolumeValue = PlayerPrefs.GetFloat("Master Volume");
        masterVolumeSlider = GameObject.Find("Master Volume Slider");
        masterVolumeSlider.GetComponent<Slider>().value = masterVolumeValue;
        AudioListener.volume = masterVolumeValue;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        masterVolumeSlider.GetComponent<Slider>().value = masterVolumeValue;
        AudioListener.volume = masterVolumeValue;
    }
   public void OnValueChanged()
    {
        masterVolumeValue = masterVolumeSlider.GetComponent<Slider>().value;
        AudioListener.volume = masterVolumeValue;
        PlayerPrefs.SetFloat("Master Volume", masterVolumeValue);
    }
}
