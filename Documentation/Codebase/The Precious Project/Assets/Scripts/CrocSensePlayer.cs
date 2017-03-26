using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocSensePlayer : MonoBehaviour {

    [SerializeField]
    GameObject jawJoint;

    void OnTriggerEnter(Collider collider)
    {
        if (jawJoint.GetComponent<Crocodile>().AtRest && collider.tag == "Player")
            jawJoint.GetComponent<Crocodile>().Bite();
    }
}
