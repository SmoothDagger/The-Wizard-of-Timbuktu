
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_World1 : MonoBehaviour
{
    
    public Transform Object;
    public Vector3 Origin;
    public Vector3 DestinationVec3;
    public Transform Destination;
    public float Speed = 2;  
    public PlayerController Player;
    public bool atEnd;
    public float waitTime = 0.0f;

    private Transform playerTransform;

    void Start()
    {
        Object = transform.FindChild("Object");
        Origin = Object.transform.position;
        Destination = transform.FindChild("Destination");
        DestinationVec3 = Destination.position;
        GameObject player = GameObject.FindWithTag("Player");
        Player = player.GetComponent<PlayerController>();
        playerTransform = player.transform;
    }

    void Update()
    {
        if (transform.position == Origin)
        {
            if (waitTime < 1f)
            {
                waitTime += Time.deltaTime;
                return;
            }
        }
        if (!atEnd)
        {
            if (Object.transform.position == Origin)
                DestinationVec3 = Destination.position;
            // else if (Object.transform.position == DestinationVec3)
            // Object.GetComponent<Animator>().SetTrigger("Destroy_Boss");
            Object.transform.position = Vector3.MoveTowards(Object.transform.position, DestinationVec3, Speed * Time.deltaTime);

            if (Object.transform.position == DestinationVec3)
                atEnd = true;
        }

        else
        {
            if (waitTime < 5f)
            {
                waitTime += Time.deltaTime;
                return;
            }

            Object.transform.position = Vector3.MoveTowards(Object.transform.position, Origin, Speed * 0.2f * Time.deltaTime);

        }
    }

    void LateUpdate()
    {
        if (!Player.IsAlive || Object.transform.position.x > playerTransform.position.x)
        {
            transform.position = Origin;
            Object.transform.position = Origin;
            atEnd = false;
            waitTime = 0;
        }
    }

    
}
