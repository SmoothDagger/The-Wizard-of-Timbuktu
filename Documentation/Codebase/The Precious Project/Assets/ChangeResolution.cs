using UnityEngine;
using UnityEngine.UI;

public class ChangeResolution : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Resolution[] resolutions;

    public void Start()
    {
        fullscreenToggle = GameObject.Find("Fullscreen Toggle").GetComponent<Toggle>();
        resolutionDropdown = GameObject.Find("Resolution Dropdown").GetComponent<Dropdown>();
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void FullScreen()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }
}