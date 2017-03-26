using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {
    GameObject player;
    GameObject animatorObjectInPlayer;
    PlayerController playerScript;
    Animator playerAnimator;
    SpriteRenderer playerSR;
    bool flipOnce;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = GetComponent<PlayerController>();
        playerAnimator = player.GetComponentInChildren<Animator>();
        playerSR = player.GetComponentInChildren<SpriteRenderer>();
        //Animator Parameters:
        //Jump (bool)
        //Speed (float)
        //Levitate (bool)
        //Dead (bool)
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (playerScript.transform.parent == null && playerScript.movingLeft && !playerSR.flipX)
        {
            flipOnce = true;
            playerSR.flipX = true;
        }
        else if (playerScript.transform.parent == null && !playerScript.movingLeft && playerSR.flipX)
        {
            flipOnce = true;
            playerSR.flipX = false;
        }
        else if (playerScript.transform.parent != null && playerScript.transform.parent.parent.parent.transform.localScale.x <= 0.0f && flipOnce)
        {
            flipOnce = false;
            playerSR.flipX = !playerSR.flipX;
        }

        playerAnimator.SetBool("Moving", playerScript.IsMoving());
        playerAnimator.SetBool("Dead", !playerScript.IsAlive);
        playerAnimator.SetBool("Jump", playerScript.didPlayerJump);
        playerAnimator.SetBool("Levitate", playerScript.isPlayerLevitating);
        playerAnimator.SetBool("Grounded", playerScript.IsPlayerGrounded());
    }
}
