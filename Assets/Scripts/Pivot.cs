using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject myPlayer;
    Vector2 playerMovement;
    Vector2 mousePos;

    // Rigidbody and Camera 
    public Rigidbody2D rb;
    public Camera cam;

    //Speed in wihch player will move 
    public float speed = 20f;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;

    void Update()
    {

        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    }


    void FixedUpdate()
    {
        Vector3 v3Pos;
        float fAngle;

        // Using positoins from update function this line of code will enable the player to move
        rb.MovePosition(rb.position + playerMovement * speed * Time.fixedDeltaTime);

        // Calculate the position the player wants to look in by subtracting the 2 vectors mouse position and player position
        Vector2 lookDir = mousePos - rb.position;
        lookDir.Normalize();
        // Using Atan to calculate the x-axis to the directional vector using the lookDir, The player can look around with the Mouse, Atan is convereted from Radians to Degrees
        float viewAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = viewAngle;


        v3Pos = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
        v3Pos = Input.mousePosition - v3Pos;
        fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg;
        if (fAngle < 0.0f) fAngle += 360.0f;

        Debug.Log(fAngle);

        if (fAngle >= 45 && fAngle <= 135)
        {
            ChangeSpriteBack();

        }

        else
        {
            if (fAngle >= 135 && fAngle <= 225)
            {
                ChangeSprite();
            }

            else
            {
                if (fAngle >= 225 && fAngle <= 315)
                {
                    ChangeSpriteBack();
                }

                else
                {
                    ChangeSprite();
                }
            }

        }

        void ChangeSprite()
        {
            spriteRenderer.sprite = newSprite;
           
        }

        void ChangeSpriteBack()
        {
            spriteRenderer.sprite = oldSprite;
        }

    }
}
