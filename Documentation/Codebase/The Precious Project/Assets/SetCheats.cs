using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCheats : MonoBehaviour
{
    List<Toggle> toggles;
    bool allOn;

    private void Start()
    {
        toggles = new List<Toggle>();
        GetToggles();
    }

    public void ToggleStopTimer()
    {
        CheatManager.Instance.ToggleStopTimer();
    }

    public void ToggleGodMode()
    {
        CheatManager.Instance.ToggleGodMode();
    }

    public void ToggleTimeStopCD()
    {
        CheatManager.Instance.ToggleTimeStopCD();
    }

    public void ToggleDoubleSpeed()
    {
        CheatManager.Instance.ToggleDoubleSpeed();
    }

    public void ToggleAll()
    {
        allOn = !allOn;
        toggles.ForEach(x => x.isOn = allOn);

        if (allOn)
            CheatManager.Instance.EnableAll();
        else
            CheatManager.Instance.DisableAll();
    }

    void GetToggles()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Cheats Toggle"))
                toggles.Add(child.gameObject.GetComponent<Toggle>());
        }
    }
}
