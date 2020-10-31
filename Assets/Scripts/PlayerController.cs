    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //2D Vectors made to store player poisiton and mouse postion
    Vector2 playerMovement;
    
    //Speed in wihch player will move 
    public float playerSpeed = 20f;

    // Rigidbody and Camera 
    public Rigidbody2D rb;
    public Camera cam;
    public SpriteRenderer ammoRenderer;
    public Sprite newAmmo;
    public Sprite originalAmmo;
    
    public bool shotgunPicked = false;
    public bool ak47Picked = false;
    public bool icePicked = false;
    public bool batteryPicked = false;

    public CrosshairAimPlusShoot bullet; 

    // Variable to store Player's Health
    public float playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
    //Assign Player Health to 100
        playerHealth = 100;
        
    }

    // Update is called once per frame
      
 
     void Update () {
        // Get the players postion constantly through the update function
         playerMovement.x = Input.GetAxisRaw("Horizontal");
         playerMovement.y = Input.GetAxisRaw("Vertical");
          
          // Whenplayer reaches 0 health destroy Player game object
          if(playerHealth == 0){
            
            Destroy (gameObject);
     }

        Debug.Log(playerHealth);

     //   if (icePicked == true){
     //       ChangeAmmo();
      //  }

       if (Input.GetKeyDown(KeyCode.Tab)){
           ChangeAmmoBack();
       }

    }

      void FixedUpdate() {
        // Using positoins from update function this line of code will enable the player to move
        rb.MovePosition(rb.position + playerMovement * playerSpeed * Time.fixedDeltaTime);
        // Calculate the position the player wants to look in by subtracting the 2 vectors mouse position and player position   
     }

     void OnCollisionEnter2D(Collision2D col) {
       
        if (col.gameObject.CompareTag("MeeleEnemy")){
            //Destroy (col.gameObject);
            //Destroy (gameObject);
            playerHealth = playerHealth - 10;
        }

         if (col.gameObject.CompareTag("Ice")){
            Destroy (col.gameObject);
            icePicked = true;
            batteryPicked = false;

         }

           if (col.gameObject.CompareTag("Battery")){
            Destroy (col.gameObject);
            batteryPicked = true;
            icePicked = false;
         }

         if (col.gameObject.CompareTag("Shotgun")){
            Destroy (col.gameObject);
            shotgunPicked = true;
            ak47Picked = false;
         }

         if (col.gameObject.CompareTag("AK47")){
            Destroy (col.gameObject);
            shotgunPicked = false;
            ak47Picked = true;
         }
    }

      

      void ChangeAmmo()
    {
        ammoRenderer.sprite = newAmmo; 
    }

       void ChangeAmmoBack()
    {
        ammoRenderer.sprite = originalAmmo; 
    }

    
}
