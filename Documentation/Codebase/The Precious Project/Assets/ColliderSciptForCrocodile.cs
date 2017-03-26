using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSciptForCrocodile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (transform.parent.GetComponent<Transform>().localRotation.x <= -40f)
	    {
	        transform.GetComponent<BoxCollider>().enabled = false;
	    }
	    else
	    {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
	}
}
