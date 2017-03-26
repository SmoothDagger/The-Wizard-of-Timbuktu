using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour {

    [SerializeField]
    GameObject upperJaw;
    RotateOnTimer[] rotators;
    [SerializeField]
    float delay;
    float timer;
    bool atRest = true;
    AudioSource audioSource;

    public bool AtRest
    {
        get
        {
            return atRest;
        }
    }

    void Start () {
        timer = delay;
        rotators = GetComponents<RotateOnTimer>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void FixedUpdate () {
        if (!atRest)
        {
            if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
            }
            else if (rotators[0].enabled == true)
            {
                
                rotators[0].enabled = false; //end wiggle
                rotators[1].enabled = true; //start snap
                upperJaw.GetComponent<BoxCollider>().enabled = true;
                audioSource.Play();
            }
            else if (transform.rotation.eulerAngles.x < 0.1f)
            {

                rotators[1].enabled = false; // end snap
                upperJaw.GetComponent<BoxCollider>().enabled = false;
                atRest = true;
                timer = delay;
            }
        }

        //if (transform.FindChild("UpperJaw").GetComponent<Transform>().rotation.x > -41.9f)
        //{
        //    transform.FindChild("UpperJaw").GetComponent<BoxCollider>().enabled = true;
        //}
        //else if (transform.FindChild("UpperJaw").GetComponent<Transform>().rotation.x < -40.1f)
        //{
        //    transform.FindChild("UpperJaw").GetComponent<BoxCollider>().enabled = false;
        //    //upperJaw.GetComponent<BoxCollider>().enabled = toggleCollider;

        //}
    }

    public void Bite()
    {
        atRest = false;
        rotators[0].enabled = true; // start wiggle
    }
}
