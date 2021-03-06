﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMoveRotate : MonoBehaviour
{
    //2D Vectors made to store player poisiton and mouse postion
    Vector2 playerMovement;
    Vector2 mousePos;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite oldSprite;

    //Speed in wihch player will move 
    public float speed = 20f;

    // Rigidbody and Camera 
    public Rigidbody2D rb;
    public Camera cam;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
      
 
     void Update () {

         playerMovement.x = Input.GetAxisRaw("Horizontal");
         playerMovement.y = Input.GetAxisRaw("Vertical");

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

       
     }

      void FixedUpdate() {
        // Using positoins from update function this line of code will enable the player to move
         rb.MovePosition(rb.position + playerMovement * speed * Time.fixedDeltaTime);
        // Calculate the position the player wants to look in by subtracting the 2 vectors mouse position and player position
         Vector2 lookDir = mousePos - rb.position;
         lookDir.Normalize();
        // Using Atan to calculate the x-axis to the directional vector using the lookDir, The player can look around with the Mouse, Atan is convereted from Radians to Degrees
         float viewAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg + 90f;
         rb.rotation = viewAngle;


        //   if (rb.rotation >= -45 & rb.rotation <= 45){
        //     ChangeSpriteBack();
        // }
        //  else if (rb.rotation >= 45 & rb.rotation < 115){
         //    ChangeSprite();
      //   }
       // if (rb.rotation >= 115 & rb.rotation <= -115){
         //    ChangeSpriteBack();
       //  }

         // else if (rb.rotation >= -115  & rb.rotation <= -145){
        //     ChangeSprite();
        // }
 
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
