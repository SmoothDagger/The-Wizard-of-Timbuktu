using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    void OnTriggerEnter(Collider objectCollider)
    {
       if (objectCollider.tag == "Player" && !transform.GetComponentInParent<ParentScriptForTrigger>().LogFell)
       {
           transform.parent.GetComponent<ParentScriptForTrigger>().Fall();
           GetComponent<AudioSource>().Play();
       }
    }
}
