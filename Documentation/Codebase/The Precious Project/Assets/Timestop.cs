using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timestop : MonoBehaviour
{
    bool isTimeStopped;
    bool keepResetting;
    bool canTimeStop;
    bool wasTimeStopped;
    float timeStopLength;
    float timeScaleTime;
    float beenFrozenTime;
    float cooldownTime;

    PlayerController player;
    GameObject timeStopSoundSource;
    Image timeStopImageOnHUD;
    Color colorForImage;
    GameObject timestopPanel;
    Color colorForPanel;

    // Use this for initialization
    void Start()
    {
        wasTimeStopped = false;
        cooldownTime = 10.0f;
        timeStopLength = 4.0f;
        timeScaleTime = Time.timeScale;
        canTimeStop = true;
        player = GetComponent<PlayerController>();
        timeStopSoundSource = GameObject.Find("TimeStopSoundSource");
        timeStopImageOnHUD = GameObject.Find("TimeStopImage").GetComponent<Image>();
        colorForImage = timeStopImageOnHUD.color;
        timestopPanel = GameObject.Find("Timestop Panel");
        colorForPanel = timestopPanel.GetComponent<Image>().color;
        colorForImage.a = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wasTimeStopped && !isTimeStopped && cooldownTime > 0.0f)
        {
            cooldownTime -= Time.deltaTime;
            colorForImage.a = cooldownTime;
        }

        if (cooldownTime <= 0.0f)
        {
            cooldownTime = 10.0f;
            canTimeStop = true;
            colorForPanel.a = 0.0f;
            wasTimeStopped = false;
            colorForImage.a = 0.0f;
        }
        if (!player.IsAlive)
        {
            Time.timeScale = 1.0f;
            keepResetting = false;
            beenFrozenTime = 0.0f;
            canTimeStop = true;
            timeStopSoundSource.GetComponent<AudioSource>().Stop();
            isTimeStopped = false;
            cooldownTime = 10.0f;
            colorForPanel.a = 0.0f;
            wasTimeStopped = false;
            colorForImage.a = 0.0f;
        }
        if (isTimeStopped && !keepResetting)
        {
            beenFrozenTime += Time.deltaTime;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0.2f, beenFrozenTime / 30.0f);
            colorForPanel.a = Mathf.Lerp(0, 1, beenFrozenTime / 4.5f);
            timeScaleTime = Time.timeScale;
            canTimeStop = false;
            wasTimeStopped = true;
            colorForImage.a = beenFrozenTime;
        }

        if (beenFrozenTime >= timeStopLength && isTimeStopped)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f, beenFrozenTime / 120.0f);
            colorForPanel.a = Mathf.Lerp(colorForPanel.a, 0, Time.timeScale /*/ 1.0f*/);
            isTimeStopped = false;
            canTimeStop = false;
            beenFrozenTime -= Time.deltaTime;
            timeScaleTime = Time.timeScale;
            keepResetting = true;
            wasTimeStopped = true;
            colorForImage.a = beenFrozenTime;
        }

        if (keepResetting)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f, beenFrozenTime / 120.0f);
            colorForPanel.a = Mathf.Lerp(colorForPanel.a, 0, Time.timeScale /*/ 1.0f*/);
            beenFrozenTime -= Time.deltaTime;
            timeScaleTime = Time.timeScale;
            cooldownTime = 10.0f;
            canTimeStop = false;
            wasTimeStopped = true;
        }

        if (beenFrozenTime <= 0.0f)
        {
            keepResetting = false;
            beenFrozenTime = 0.0f;
            colorForPanel.a = 0.0f;
        }
        timeScaleTime = Time.timeScale;
        timeStopImageOnHUD.color = colorForImage;
        timestopPanel.GetComponent<Image>().color = colorForPanel;
    }

    public void StopTime()
    {
        if (canTimeStop && !isTimeStopped)
        {
            isTimeStopped = true;
            beenFrozenTime += Time.deltaTime;
            canTimeStop = false;
            timeStopSoundSource.GetComponent<AudioSource>().Play();
        }
    }

    public bool CanTimeStop()
    {
        return canTimeStop;
    }

    public void Reset()
    {
        if (!canTimeStop && !isTimeStopped)
            canTimeStop = true;
    }

    public bool isTimeCurrentlyBeingStopped()
    {
        return isTimeStopped;
    }
}