using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour {
    public GameObject tpDestination;
    public Transform jumpPoint;
    // Use this for initialization
    void Start () {
        tpDestination = GameObject.Find("Jump Destination");
        jumpPoint = tpDestination.transform;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&&Input.GetButtonDown("Confirm"))
            other.transform.position = jumpPoint.transform.position;
    }
}
