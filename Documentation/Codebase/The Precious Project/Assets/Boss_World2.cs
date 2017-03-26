
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_World2 : MonoBehaviour
{

    public Transform Object;
    public Vector3 Origin;
    public Vector3 DestinationVec3;
    public Transform Destination;
    public float Speed = 2;
    public PlayerController Player;
    GameObject spawnPoint;

    void Start()
    {
        Object = transform.FindChild("Object");
        Origin = Object.transform.position;
        Destination = transform.FindChild("Destination");
        DestinationVec3 = Destination.position;
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        spawnPoint = GameObject.FindWithTag("SpawnPoint");
    }

    void Update()
    {
        //if (Object.transform.position == Origin)
        //    DestinationVec3 = Destination.position;
        // else if (Object.transform.position == DestinationVec3)
        // Object.GetComponent<Animator>().SetTrigger("Destroy_Boss");
        Object.transform.position = Vector3.MoveTowards(Object.transform.position, DestinationVec3, Speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (!Player.IsAlive)
        {
            transform.position = Origin;
            Object.transform.position = Origin + new Vector3(0, spawnPoint.transform.position.y-5, 0);
            DestinationVec3 = Destination.position;
        }
    }


}
