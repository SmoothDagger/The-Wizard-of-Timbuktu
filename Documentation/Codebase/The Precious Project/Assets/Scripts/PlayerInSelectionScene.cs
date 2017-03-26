using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInSelectionScene : MonoBehaviour {
    private Vector3 input;
    private float movespeed=20f;
    private float maxspeed=10f;
    [SerializeField]
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.position.x <= -14.5f)
            rb.position = new Vector3(-14.5f, rb.position.y, rb.position.z);
        else if(rb.position.x>=14.5f)
            rb.position = new Vector3(14.5f, rb.position.y, rb.position.z);
        if (rb.position.z <= -13.5f)
            rb.position = new Vector3(rb.position.x, rb.position.y, -13.5f);
        else if (rb.position.z >= 13.5f)
            rb.position = new Vector3(rb.position.x, rb.position.y, 13.5f);


        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
         if (rb.velocity.magnitude < maxspeed)
          {
              rb.AddForce(input * movespeed);
          }
             
	}
}
