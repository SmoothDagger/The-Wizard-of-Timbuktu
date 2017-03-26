using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointCounter : MonoBehaviour {
    GameObject[] checkpoints;
    Timer timerInstance;
	// Use this for initialization
	void Start () {
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        timerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Checkpoints: " + timerInstance.GetCheckpointCount() + "/" + checkpoints.Length;
	}
}
