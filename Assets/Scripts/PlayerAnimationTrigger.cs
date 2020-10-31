using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    public GameObject myPlayer;
    public Animator animator;
    public PlayerController speedv;
    private float runspeed;

    void Update()
    {

        Vector3 v3Pos;
        float fAngle;
        runspeed = speedv.playerSpeed;


        v3Pos = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
        v3Pos = Input.mousePosition - v3Pos;
        fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (fAngle < 0.0f) fAngle += 360.0f;


        if (fAngle >= 45 && fAngle <= 135)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Back", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);

            if (runspeed > 0)
            {
                animator.SetFloat("Speed", 1);
            }
            else if (runspeed <= 0)
            {
                animator.SetFloat("Speed", 0);
            }
        }

        else
        { 
            if (fAngle >= 135 && fAngle <= 225)
            {
                animator.SetBool("Forward", false);
                animator.SetBool("Back", false);
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
            }

            else
            {
                if (fAngle >= 225 && fAngle <= 315)
                {
                    animator.SetBool("Forward", true);
                    animator.SetBool("Back", false);
                    animator.SetBool("Left", false);
                    animator.SetBool("Right", false);
                }

                else
                {
                        animator.SetBool("Forward", false);
                        animator.SetBool("Back", false);
                        animator.SetBool("Left", false);
                        animator.SetBool("Right", true);
                }
            }




        }
















    }



}
