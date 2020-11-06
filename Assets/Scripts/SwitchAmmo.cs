using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAmmo: MonoBehaviour
{

    //Booleans to check current ammo
   // private bool bulletPistol = true; 
    private bool pis = true;
    private bool fir = false;   
    private bool ice = false;   
    private bool batt = false;   
    private bool bulletIce;
    private bool bulletFire;
    private bool bulletLightning;
    
    // GameObject holding script to be added in inspector in order to access current ammo
    public PlayerController items;
    public CurrentAmmo UI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fir);
        //Call CheckAmmo Function once per frame
        CheckAmmo();
        //Call CheckAmmo Function once per frame
      //  CheckUI();
    }

     void CheckAmmo(){
    // Call the PlayerController script once per frame to check the booleans state constantly to see current ammo 
        //bulletUI = items.bulletNormal;
        bulletFire = items.emberPicked;
        bulletIce = items.icePicked;
        bulletLightning = items.batteryPicked;
        SortAmmo();
        ChangeAmmo();
        
    }

  //  void checkUI(){
       
   // }
     void SortAmmo(){
        //If Bullet is fire OR ice Or lightning set bullet to false
        if(bulletFire == true || bulletIce == true ||bulletLightning == true){
            //bulletPistol = false;
        }
    }

    void ChangeAmmo(){
        // if pistol and fire held
        if(pis && fir == true && bulletIce == false && bulletLightning == false){
            if ((Input.GetKeyDown("q"))){
                items.emberPicked = true;
                UI.fireBulletUI = true;
                items.icePicked = false;
                items.batteryPicked = false;
                UI.bulletUI = false;
                Debug.Log(UI.bulletUI);
                
                
            }
             if ((Input.GetKeyDown("e"))){
                items.emberPicked = false;
                UI.fireBulletUI = false;
                items.icePicked = false;
                items.batteryPicked = false;
                UI.bulletUI = true;
            }
        }
        //if pistolbullet and ice held
         if(pis && fir == false && ice == true && batt == false){
            if ((Input.GetKeyDown("q"))){
                items.icePicked = true;
                UI.iceBulletUI = true;
                items.emberPicked = false;
                items.batteryPicked = false;
                UI.bulletUI = false;
                Debug.Log(UI.bulletUI);
                
                
            }
             if ((Input.GetKeyDown("e"))){
                items.emberPicked = false;
                UI.lightningBulletUI = false;
                items.batteryPicked = false;
                items.icePicked = false;
                items.batteryPicked = false;
                UI.bulletUI = true;
            }
        }
        // if pistolbullet and lightning is held
         if(pis && fir == false && ice == false && batt == true){
            if ((Input.GetKeyDown("q"))){
                items.batteryPicked = true;
                UI.lightningBulletUI = true;
                items.icePicked = false;
                items.emberPicked = false;
                UI.bulletUI = false;
                Debug.Log(UI.bulletUI);
                
                
            }
             if ((Input.GetKeyDown("e"))){
                items.emberPicked = false;
                UI.fireBulletUI = false;
                items.icePicked = false;
                items.batteryPicked = false;
                UI.bulletUI = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ember")){
            Destroy (col.gameObject);
            ice = false;
            batt = false;
            fir = true;

         }  

          if (col.gameObject.CompareTag("Ice")){
            Destroy (col.gameObject);
            ice = true;
            batt = false;
            fir = false;

         }  

          if (col.gameObject.CompareTag("Battery")){
            Destroy (col.gameObject);
            ice = false;
            batt = true;
            fir = false;

         }  
    }
}
