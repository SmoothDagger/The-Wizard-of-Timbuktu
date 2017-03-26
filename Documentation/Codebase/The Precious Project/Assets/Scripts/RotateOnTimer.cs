using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTimer : MonoBehaviour {

    [SerializeField]
    float startTime, endTime;
    float timer = 0.0f;
    bool forwards = true;
    [SerializeField]
    Quaternion startq, endq;

	void Start () {
        startTime = 1.0f / startTime;
        endTime = 1.0f / endTime;
        startq = Quaternion.Euler(startq.x, startq.y, startq.z);
        endq = Quaternion.Euler(endq.x, endq.y, endq.z);
	}
	
	void Update () {
        timer += Time.deltaTime;
        if (forwards)
        {
            rotate(startq, endq, startTime);
        }
        else
        {
            rotate(endq, startq, endTime);
        }
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

    //public void RotateRhino()
    //{

    //    startq = Quaternion.Euler(startq.x, startq.y, startq.z*(-1));
    //    endq = Quaternion.Euler(endq.x, endq.y, endq.z*(-1));
    //}
}
