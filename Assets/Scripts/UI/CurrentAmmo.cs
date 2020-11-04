using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmo : MonoBehaviour
{
     // Sprites to be added in editor
    public Sprite bulletSprite;
    public Sprite iceBulletSprite;
    public Sprite lightningBulletSprite;
    public Sprite fireBulletSprite;

    private bool bulletUI = true;    
    private bool iceBulletUI;
    private bool fireBulletUI;
    private bool lightningBulletUI;

    public Image ammoImg;
    

    // GameObject holding script to be added in inspector in order to access current weapon
    public PlayerController items;

    // Start is called before the first frame update
    void Start()
    {
         // Get image component in order to change UI
         ammoImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Call CheckAmmo Function once per frame
        CheckAmmo();
    }

    void CheckAmmo(){
    // Call the PlayerController script once per frame to check the booleans state constantly to see current ammo 
        //bulletUI = items.bulletNormal;
        fireBulletUI = items.emberPicked;
        iceBulletUI = items.icePicked;
        lightningBulletUI = items.batteryPicked;
        SortAmmo();
    //If functions used to check current ammo and then change sprite depending on result
        if(bulletUI == true && fireBulletUI == false && iceBulletUI == false && lightningBulletUI == false){
            ammoImg.sprite = bulletSprite;
        }
        if(bulletUI ==false  && fireBulletUI == true && iceBulletUI == false && lightningBulletUI == false){
            ammoImg.sprite = fireBulletSprite;
        }
        if(bulletUI == false && fireBulletUI == false && iceBulletUI == true && lightningBulletUI == false){
            ammoImg.sprite = iceBulletSprite;
        }
        if(bulletUI == false && fireBulletUI == false && iceBulletUI == false && lightningBulletUI == true){
            ammoImg.sprite = lightningBulletSprite;
        }
    }

    void SortAmmo(){
        if(fireBulletUI == true || iceBulletUI == true ||lightningBulletUI == true){
            bulletUI = true;
        }
    }
}
