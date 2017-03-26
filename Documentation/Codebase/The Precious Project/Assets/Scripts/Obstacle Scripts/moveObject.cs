using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveObject : MonoBehaviour {

    public Transform Object;
    public Vector3 Origin;
    public Vector3 DestinationVec3;
    public Transform Destination;
    public float Speed = 2;
    float xDirection;
    public bool MovementBool = true;
    public bool ShooterObstacle = false;
    [SerializeField] public float DelayTimerForShoot = 5.0f;



	// Use this for initialization
	void Start ()
    { 
        Object = transform.FindChild("Object");
        Origin = Object.transform.position;
        Destination = transform.FindChild("Destination");
	    DestinationVec3 = Destination.position;
        //xDirection = Object.transform.localScale.x * -1;
        //Object.localScale = new Vector3(xDirection, 2, 1);


    }

    IEnumerator DelayForShoot(float DelayTimerForShoot)
    {
        
        yield return new WaitForSecondsRealtime(DelayTimerForShoot);
        Object.transform.position = Origin;
        DestinationVec3 = Destination.position;
    }
	// Update is called once per frame
	void Update ()
	{

	    if (Object.transform.position == Origin)
	    {
            DestinationVec3 = Destination.position;
            //xDirection = Object.transform.localScale.x * -1;
            //Object.localScale = new Vector3(xDirection, 2, 1);
        }
	        
        else if (Object.transform.position == DestinationVec3)
	    {
	        if (ShooterObstacle == true)
	        {
                StartCoroutine(DelayForShoot(DelayTimerForShoot));
                

                //foreach (Transform child in transform)
                //{
                //    Debug.Log("entered foreach");
                //    if (child.name == "Object")
                //    {
                //        GameObject.Destroy(child.gameObject);
                //    } 
                //}

                //Destroy(gameObject);
                ////Add delay and create a new saw blade

            }

	        else
	        {
                DestinationVec3 = Origin;
                //xDirection = Object.transform.localScale.x * -1;
                //Object.localScale = new Vector3(xDirection, 2, 1);
            }
           
        }

        if (MovementBool == true)
        {
            Object.transform.position = Vector3.MoveTowards(Object.transform.position, DestinationVec3, Speed * Time.deltaTime);

        }


    }



}
