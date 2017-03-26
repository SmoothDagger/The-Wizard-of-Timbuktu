using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

    public GameObject xyz;
    GameObject spawnpoint;
    GameObject checkpointSpawn;

	void Start () {
        spawnpoint = GameObject.FindWithTag("SpawnPoint");
        checkpointSpawn = GameObject.FindWithTag("CheckPointSpawn");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnpoint.transform.position = checkpointSpawn.transform.position;
        }
    }
}
