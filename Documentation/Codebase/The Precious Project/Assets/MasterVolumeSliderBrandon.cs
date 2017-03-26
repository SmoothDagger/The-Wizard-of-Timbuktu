using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeSliderBrandon : MonoBehaviour {

    public GameObject volumeSlider;
    public GameObject audioSourceObject;
    public float volumeValue;
    // Use this for initialization
    void Start()
    {
        audioSourceObject = GameObject.Find("AudioSourceObject");
        volumeSlider = GameObject.Find("slider_MasterVolume");
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Master Volume");
        audioSourceObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Master Volume");
    }

    // Update is called once per frame
    void Update()
    {
        volumeValue = volumeSlider.GetComponent<Slider>().value;
        audioSourceObject.GetComponent<AudioSource>().volume = volumeValue;

    }
    public void OnValueChanged()
    {
        PlayerPrefs.SetFloat("Master Volume", volumeValue);
    }
}
