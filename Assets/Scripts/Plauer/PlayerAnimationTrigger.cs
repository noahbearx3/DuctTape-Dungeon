using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    public GameObject myPlayer;
    public Animator pbodyanimator;
    public Sprite HeadFront;
    public Sprite HeadRight;
    public Sprite HeadLeft;
    public Sprite HeadBack;
    public SpriteRenderer spriteRenderer;
    public PlayerController weaponCheck;
    public Sprite Shotgun;
    public Sprite AK;
    public Sprite Pistol;
    public SpriteRenderer weaponRenderer;



    void Update()
    {

        Vector3 v3Pos;
        float fAngle;


        v3Pos = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
        v3Pos = Input.mousePosition - v3Pos;
        fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (fAngle < 0.0f) fAngle += 360.0f;


        if (fAngle >= 45 && fAngle <= 135)
        {
            pbodyanimator.SetBool("Front", false);
            pbodyanimator.SetBool("Back", true);
            pbodyanimator.SetBool("Left", false);
            pbodyanimator.SetBool("Right", false);
            LookBack();
        }


        else
        { 
            if (fAngle >= 135 && fAngle <= 225 )
            {
                pbodyanimator.SetBool("Front", false);
                pbodyanimator.SetBool("Back", false);
                pbodyanimator.SetBool("Left", true);
                pbodyanimator.SetBool("Right", false);
                LookLeft();
            }

            else
            {
                if (fAngle >= 225 && fAngle <= 315)
                {
                    pbodyanimator.SetBool("Front", true);
                    pbodyanimator.SetBool("Back", false);
                    pbodyanimator.SetBool("Left", false);
                    pbodyanimator.SetBool("Right", false);
                    LookFront();
                }
                
               else
                {
                    pbodyanimator.SetBool("Front", false);
                    pbodyanimator.SetBool("Back", false);
                    pbodyanimator.SetBool("Left", false);
                    pbodyanimator.SetBool("Right", true);
                    LookRight();


                }
                



            }



        }
        if (Input.GetKey(KeyCode.D))
        {
            pbodyanimator.SetBool("Running", true);
            pbodyanimator.SetBool("RightRun", true);
            pbodyanimator.SetBool("BackRun", false);
            pbodyanimator.SetBool("LeftRun", false);
            pbodyanimator.SetBool("FrontRun", false);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            pbodyanimator.SetBool("Running", false);
            pbodyanimator.SetBool("RightRun", false);
        }
        

        if (Input.GetKey(KeyCode.W))
        {
            pbodyanimator.SetBool("Running", true);
            pbodyanimator.SetBool("BackRun", true);
            pbodyanimator.SetBool("RightRun", false);
            pbodyanimator.SetBool("LeftRun", false);
            pbodyanimator.SetBool("FrontRun", false);

        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            pbodyanimator.SetBool("Running", false);
            pbodyanimator.SetBool("BackRun", false);
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            pbodyanimator.SetBool("Running", true);
            pbodyanimator.SetBool("LeftRun", true);
            pbodyanimator.SetBool("RightRun", false);
            pbodyanimator.SetBool("BackRun", false);
            pbodyanimator.SetBool("FrontRun", false);

        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            pbodyanimator.SetBool("Running", false);
            pbodyanimator.SetBool("LeftRun", false);
        }

    
        if (Input.GetKey(KeyCode.S))
        {
            pbodyanimator.SetBool("Running", true);
            pbodyanimator.SetBool("FrontRun", true);
            pbodyanimator.SetBool("RightRun", false);
            pbodyanimator.SetBool("BackRun", false);
            pbodyanimator.SetBool("LeftRun", false);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            pbodyanimator.SetBool("Running", false);
            pbodyanimator.SetBool("FrontRun", false);
        }
        
            if (weaponCheck.shotgunPicked == true)
            {
                weaponRenderer.sprite = Shotgun;
            }
            else
            {
                if(weaponCheck.ak47Picked == true)
                {
                    weaponRenderer.sprite = AK;
                }
                else
                {
                    weaponRenderer.sprite = Pistol;
                }
        }

    }


    void LookFront()
    {
        spriteRenderer.sprite = HeadFront;
    }

    void LookLeft()
    {
        spriteRenderer.sprite = HeadLeft;
    }

    void LookRight()
    {
        spriteRenderer.sprite = HeadRight;
    }

    void LookBack()
    {
        spriteRenderer.sprite = HeadBack;
    }


}
