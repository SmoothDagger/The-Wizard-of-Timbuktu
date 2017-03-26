using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXOnTimer : MonoBehaviour {

    [SerializeField]
    float startTime, endTime;
    float timer = 0.0f;
    bool forwards = true;
    Quaternion startq, endq;

    void Start()
    {
        startTime = 1.0f / startTime;
        endTime = 1.0f / endTime;
        startq = Quaternion.Euler(0, 0.0f, 0.0f);
        endq = Quaternion.Euler(0, 0.0f, 0.0f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (forwards)
            rotate(startq, endq, startTime);
        else
            rotate(endq, startq, endTime);
    }

    void rotate(Quaternion _a, Quaternion _b, float time)
    {
        transform.rotation = Quaternion.Lerp(_a, _b, timer * time);
        if (timer * time >= 1.0f)
        {
            forwards = !forwards;
            timer = 0.0f;
        }
    }
}
