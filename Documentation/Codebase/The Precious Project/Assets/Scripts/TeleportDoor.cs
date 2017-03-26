using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour {
    public GameObject tpDestination;
    public Transform tpPoint;
    // Use this for initialization
    void Start()
    {
        tpDestination = GameObject.Find("TP Destination");
        tpPoint = tpDestination.transform;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = tpPoint.transform.position;
            GetComponent<AudioSource>().Play();
        }
    }
}
