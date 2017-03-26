using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingRhino : MonoBehaviour
{

    public Transform Object;
    public Transform joint;
    public Vector3 Origin;
    public Vector3 DestinationVec3;
    public Transform Destination;
    public float Speed = 2;
    float xDirection;
    public bool MovementBool = true;
    public bool ShooterObstacle = false;
    //[SerializeField]
    //public float DelayTimerForShoot = 5.0f;
    [SerializeField]
    public float x=0.5f;
    //private float xscale = 0.5714285f;
    //private float yscale = 0.833f;


    // Use this for initialization
    void Start()
    {
        Object = transform.FindChild("Object");
        Origin = Object.transform.position;
        Destination = transform.FindChild("Destination");
        DestinationVec3 = Destination.position;
        xDirection = Object.transform.localScale.x * -1;
        Object.localScale = new Vector3(xDirection, 2, 1);
        // joint = Object.transform.FindChild("Body").FindChild(("Joint")); 


    }

    
    // Update is called once per frame
    void Update()
    {

        if (Object.transform.position == Origin)
        {
            DestinationVec3 = Destination.position;
            xDirection = Object.transform.localScale.x * -1;
            Object.localScale = new Vector3(xDirection, 2, 1);



          //  Object.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            //joint.transform.localPosition = new Vector3(x * (-1), 0, 0);
            //Debug.Log("PositionMoved");
            //joint.transform.localScale = new Vector3(xscale*(-1), yscale, 0);
            //Debug.Log("PositionScaled");
            //  joint.GetComponent<RotateOnTimer>().RotateRhino();
            //  Debug.Log("RotateRhino");
        }

        else if (Object.transform.position == DestinationVec3)
        {
            DestinationVec3 = Origin;
            xDirection = Object.transform.localScale.x * -1;
            Object.localScale = new Vector3(xDirection, 2, 1);




           // Object.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
      
            //joint.transform.localPosition = new Vector3(x*(-1), 0, 0);
            //joint.transform.localScale = new Vector3(xscale * (-1), yscale, 0);
            // joint.GetComponent<RotateOnTimer>().RotateRhino();
            // Debug.Log("RotateRhino");
        }

        if (MovementBool == true)
        {
            if (Mathf.Abs(DestinationVec3.x - Object.transform.position.x) < 1.5f)
            {
                Object.transform.position = Vector3.MoveTowards(Object.transform.position, DestinationVec3, 0.5f * Speed * Time.deltaTime);
            }
            else
            {
                Object.transform.position = Vector3.MoveTowards(Object.transform.position, DestinationVec3, Speed * Time.deltaTime);

            }
        }
       

    }



}
