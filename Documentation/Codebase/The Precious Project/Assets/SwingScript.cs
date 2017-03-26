using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class SwingScript : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxRotationX = 30.0f;
    public float maxRotationY = 30.0f;
    public float maxRotationZ = 30.0f;
    

    void Update()
    {
        transform.rotation = Quaternion.Euler(maxRotationX * Mathf.Sin(Time.time * speed), maxRotationY * Mathf.Sin(Time.time * speed), maxRotationZ * Mathf.Sin(Time.time * speed));
    }
}

