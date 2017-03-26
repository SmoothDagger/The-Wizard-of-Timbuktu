using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLava : MonoBehaviour {

    [SerializeField]
    public float DelayTimerForShoot = 3.5f;
    

    IEnumerator DelayForShoot(float DelayTimerForShoot)
    {


        while (true)
        {
            yield return new WaitForSecondsRealtime(DelayTimerForShoot);

            transform.GetComponentInParent<BoxCollider>().enabled = false;
            transform.GetComponent<ParticleSystem>().Stop();

            yield return new WaitForSecondsRealtime(DelayTimerForShoot);

            transform.GetComponentInParent<BoxCollider>().enabled = true;
            transform.GetComponent<ParticleSystem>().Play();
        }


        
    }

    void Start()
    {
        StartCoroutine(DelayForShoot(DelayTimerForShoot));
       

    }

    
   
}
