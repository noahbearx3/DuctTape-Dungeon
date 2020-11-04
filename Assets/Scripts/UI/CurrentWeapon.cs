using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour
{
    // Sprites to be added in editor
    public Sprite pistolSprite;
    public Sprite ak47Sprite;
    public Sprite shottieSprite;
   

    // GameObject holding script to be added in inspector in order to access current weapon
    public CrosshairAimPlusShoot bools;
    public PlayerController items;

    // Booleans to access the current weapon to display on the UI
    private bool pistolUI;    
    private bool ak47UI;
    private bool shotgunUI;
    


    public Image img;

    // Start is called before the first frame update
    void Start()
    {   
        
        // Get image component in order to change UI
         img = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Call CheckWeapon Function once per frame
        checkWeapon();
    }
    
    //Function is used to check current weapon
     void checkWeapon(){
    // Call the CrossHairAimPlusShoot script once per frame to check the booleans state constantly to see current weapon 
        pistolUI = bools.pistol;
        ak47UI = bools.ak47;
        shotgunUI = bools.shotgun;
    //If functions used to check current weapon and then change sprite depending on weapon state
        if(pistolUI == true && ak47UI == false && shotgunUI == false){
            img.sprite = pistolSprite;
        }
        if(pistolUI == false && ak47UI == true && shotgunUI == false){
            img.sprite = ak47Sprite;
        }
        if(pistolUI == false && ak47UI == false && shotgunUI == true){
            img.sprite = shottieSprite;
        }
    }
}
