using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossWorld1End : MonoBehaviour {

    public PlayerController Player;
    public Boss_World1 BossObj;
    public bool DestinationReached;
    // Use this for initialization
    void Start () {
        BossObj = GameObject.Find("Boss").GetComponent<Boss_World1>();
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if(!GameObject.Find("Destination"))
            Debug.Log("Null");
        //DestinationReached = GameObject.FindWithTag("BossDestination").GetComponent<Boss_Destination>().DestinationTriggered;
    }
	
	// Update is called once per frame
	void Update () {

       // BossObj = GameObject.Find("Boss").GetComponent<Boss_World1>();
        //DestinationReached = gameObject.GetComponentInChildren<Boss_Destination>().DestinationTriggered;
    }

    
    void OnTriggerEnter(Collider objecCollider)
    {

        if ((objecCollider.gameObject.tag == "Player"))
        {
            Player.controllable = false;
            //if (DestinationReached)
            //{
                    SceneManager.LoadScene(0);
            //}
        }

       

    }

}
