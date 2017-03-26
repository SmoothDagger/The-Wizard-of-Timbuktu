using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Destination : MonoBehaviour
{


    public bool DestinationTriggered = false;
	

    void OnTriggerEnter(Collider objectCollider)
    {
        if (objectCollider.gameObject.tag == "Obstacle")
        {
            DestinationTriggered = true;
        }
    }
}
