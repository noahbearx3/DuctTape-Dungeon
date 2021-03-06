﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool emberPicked = false;
    public float healthPickup = 25f;

    public AudioClip akPick;
    
    public AudioClip shotgunPick;

    public AudioClip healthPick;
    
    public AudioClip iced;
    public AudioClip sparked;
    public AudioClip flamed;


    public HealthController healthControl;
    public HealthBarController h;
    public CurrentAmmo UI;

    public CrosshairAimPlusShoot bullet; 
   AudioSource pistolShot;

    // Variable to store Player's Health
    public float playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
    //Assign Player Health to 100
        playerHealth = 100;
        pistolShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
 
     void Update () {
        // Get the players postion constantly through the update function
         playerMovement.x = Input.GetAxisRaw("Horizontal");
         playerMovement.y = Input.GetAxisRaw("Vertical");
         
          
          // Whenplayer reaches 0 health destroy Player game object
          if(playerHealth <= 0){
            
            Destroy (gameObject);

            // Get's the last scene number. 
            // Make sure to have the Game Over scene at the end in the Buildsettings!
            int lastscene = SceneManager.sceneCountInBuildSettings - 1;
            SceneManager.LoadScene(lastscene);
            

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
            h.SetSize(playerHealth / 100);
        }

        if (col.gameObject.CompareTag("BossEnemy")){
            //Destroy (col.gameObject);
            //Destroy (gameObject);
            playerHealth = playerHealth - 25;
            h.SetSize(playerHealth / 100);
        }

         if (col.gameObject.CompareTag("Spear")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            playerHealth = playerHealth - 10;
            h.SetSize(playerHealth / 100);
        }

        if (col.gameObject.CompareTag("Kinfe")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            playerHealth = playerHealth - 15;
            h.SetSize(playerHealth / 100);
        }

         if (col.gameObject.CompareTag("Ice")){
            //AudioSource.PlayClipAtPoint (iceHit, transform.position);
            Destroy (col.gameObject);
            icePicked = true;
            batteryPicked = false;
            emberPicked = false;
            UI.bulletUI = false;
             UI.lightningBulletUI = false;
            UI.iceBulletUI = true;

         }

          if (col.gameObject.CompareTag("Ember")){
            Destroy (col.gameObject);
            icePicked = false;
            batteryPicked = false;
            emberPicked = true;
            UI.bulletUI = false;
            //UI.fireBulletUI = true;
            UI.lightningBulletUI = false;
            UI.iceBulletUI = false;

         }

           if (col.gameObject.CompareTag("Battery")){
            AudioSource.PlayClipAtPoint (sparked, transform.position);
            Destroy (col.gameObject);
            batteryPicked = true;
            icePicked = false;
            emberPicked = false;
            UI.bulletUI = false;
            UI.lightningBulletUI = true;
         }

         if (col.gameObject.CompareTag("Shotgun")){
             AudioSource.PlayClipAtPoint (shotgunPick, transform.position);
            Destroy (col.gameObject);
            shotgunPicked = true;
            ak47Picked = false;
         }

         if (col.gameObject.CompareTag("AK47")){
             AudioSource.PlayClipAtPoint (akPick, transform.position);
            Destroy (col.gameObject);
            shotgunPicked = false;
            ak47Picked = true;
         }

         if (col.gameObject.CompareTag("Health")){
             AudioSource.PlayClipAtPoint (healthPick, transform.position);
             playerHealth = playerHealth + healthPickup;
             h.SetSize(playerHealth / 100);
             Destroy (col.gameObject);
            
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
