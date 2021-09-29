using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody2D playerRB;
    public SpriteRenderer sr;
    public bool transparent = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            sr.flipX = false;
        }
        else if (movement < 0)
        {
            sr.flipX = true;
        }

        if(transparent)
        {
            if (Mathf.Abs(playerRB.velocity.y) > 0.01f)
            {
                playerAnimator.Play("Player_In_Air");
            }
            else
            {
                if (Mathf.Abs(movement) > 0.01f)
                {
                    playerAnimator.Play("Player_Run");
                }
                else
                {
                    playerAnimator.Play("Player_Idle");
                }
            }
        } else
        {
            if (Mathf.Abs(playerRB.velocity.y) > 0.01f)
            {
                playerAnimator.Play("Player_In_Air_NT");
            }
            else
            {
                if (Mathf.Abs(movement) > 0.01f)
                {
                    playerAnimator.Play("Player_Run_NT");
                }
                else
                {
                    playerAnimator.Play("Player_Idle_NT");
                }
            }
        }
        
    }
}
