using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAimPlusShoot : MonoBehaviour
{

    public Camera cam;
    public GameObject bullet;

    public GameObject frostBullet;

    public GameObject lightningBullet;

    public GameObject emberBullet;

    public float bulletPace = 60f;
    private float ammo = 5;
    private int counter = 5;
    private float shootTimerPistol = 1;
    private float shootTimerAK = 1;
    private float shootTimerShotgun = 1;
    private float pistolRate = 3;
    private float ak47Rate = 6;
    private float shotgunRate = 1;

    private bool pickIce;
    private bool pickBatt;
    private bool pickFire;
    public bool shotgun = false;
    public bool ak47 = false;
    private bool limit = false;

    public bool pistol = true;

    private Vector3 target;
    public GameObject player;
    public GameObject gunFire;

    CrosshairAimPlusShoot icePicked;    
    public Rigidbody2D rb;

    private Vector2 crosshairMousePos;

    public bool bulletNormal = true;

    public PlayerController boolean;   
    //AudioSource audio;
    public AudioClip pistolShot;
    public AudioClip shotgunShot;
    public AudioClip iceShot;
    public AudioClip sparkShot;
    public AudioClip fireShot;



     public ParticleSystem particleEmitter;
     //private ParticleAnimator particleAnimator;
     

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
         //audio = GetComponent<AudioSource>();
        //particleEmitter = GameObject.Find("Particle System").GetComponent<ParticleSystem>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Update Booleans to know which item is currently held
        pickIce = boolean.icePicked;
        pickBatt = boolean.batteryPicked;
        pickFire = boolean.emberPicked;
        shotgun = boolean.shotgunPicked;
        ak47 = boolean.ak47Picked;
        Debug.Log(pickFire);
        // Reset time of pistol to be shot(control fire rate)
        if(shootTimerPistol >= 0){
            shootTimerPistol -= Time.deltaTime * pistolRate;
        }
        // Reset time of ak-47 to be shot(control fire rate)
         if(shootTimerAK >= 0){
            shootTimerAK -= Time.deltaTime * ak47Rate;
        }
        // Reset time of shotgun to be shot(control fire rate)
        if(shootTimerShotgun >= 0){
            shootTimerShotgun -= Time.deltaTime * shotgunRate;
        }
        //If limit is 3 run the reset function
        
            if(counter == 3){
            limit = true;
            StartCoroutine(Reset());
            }
        
        
        if(shotgun){
            pistol = false;
            shotgun = true;
            ak47 = false;
           // Debug.Log(bulletNormal);
           // Debug.Log(ak47);
           // Debug.Log(shotgun);
            
        }
          if(ak47){
            pistol = false;
            shotgun = false;
            ak47 = true;
           // Debug.Log(bulletNormal);
          //  Debug.Log(ak47);
           // Debug.Log(shotgun);
        }
        
        crosshairMousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = crosshairMousePos;
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Vector3 difference = target - player.transform.position;

        Vector2 lookDir = crosshairMousePos - rb.position;
        // Using Atan to calculate the x-axis to the direcokDir.x) * Mathf.Rad2Deg - 90f;
         float viewAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        
    if(pistol==true && shotgun == false && ak47==false){
        if(pistol==true && shotgun == false && ak47== false && pickIce == false && pickBatt == false && pickFire == false){
            if(ammo > 0 && shootTimerPistol <=0){
                if (Input.GetMouseButtonDown(0) && !limit){
                    counter = counter + 1;
                    shootTimerPistol = 1;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    AudioSource.PlayClipAtPoint (pistolShot, transform.position);
                    fireBullet(direction,viewAngle);
                }
        }
        
        }
        if(pistol==true && shotgun == false && ak47== false && pickIce == true && pickBatt == false & pickFire == false){
         if(ammo > 0 && shootTimerPistol <=0){
                if (Input.GetMouseButtonDown(0) && !limit){
                    counter = counter + 1;
                    shootTimerPistol = 1;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    AudioSource.PlayClipAtPoint (iceShot, transform.position);
                    fireBullet(direction,viewAngle);
                }
        }
        
        }
        if(pistol==true && shotgun == false && ak47== false && pickIce == false && pickBatt == true && pickFire == false){
         if(ammo > 0 && shootTimerPistol <=0){
                if (Input.GetMouseButtonDown(0) && !limit){
                    counter = counter + 1;
                    shootTimerPistol = 1;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    AudioSource.PlayClipAtPoint (sparkShot, transform.position);
                    fireBullet(direction,viewAngle);
                }
        }

        
        
        }
        if(pistol==true && shotgun == false && ak47== false && pickIce == false && pickBatt == false && pickFire == true){
         if(ammo > 0 && shootTimerPistol <=0){
                if (Input.GetMouseButtonDown(0) && !limit){
                    counter = counter + 1;
                    shootTimerPistol = 1;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    AudioSource.PlayClipAtPoint (fireShot, transform.position);
                    fireBullet(direction,viewAngle);
                }
        }
    
    }
}

    // Shotgun If Controller


    if(pistol==false && shotgun == true && ak47==false){
        if(pistol==false && shotgun == true && ak47== false && pickIce == false && pickBatt == false && pickFire == false){
        if(ammo > 0 && shootTimerShotgun <=0){
                if (Input.GetMouseButtonDown(0)){
                bulletPace = 10;
                shootTimerShotgun = 1;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                Vector2 offset = Vector2.right ;
                // /int offset = difference / distance + 10;
                direction.Normalize();
                AudioSource.PlayClipAtPoint (shotgunShot, transform.position);
                fireBullet(direction + offset/2 ,viewAngle );
                fireBullet(direction - offset/2,viewAngle );
                fireBullet(direction,viewAngle);
                }
            }
        
        }
    }
        if(pistol==false && shotgun == true && ak47== false && pickIce == true && pickBatt == false & pickFire == false){
        if(ammo > 0 && shootTimerShotgun <=0){
                if (Input.GetMouseButtonDown(0)){
                bulletPace = 10;
                shootTimerShotgun = 1;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                Vector2 offset = Vector2.right ;
                // /int offset = difference / distance + 10;
                direction.Normalize();
                AudioSource.PlayClipAtPoint (iceShot, transform.position);
                fireBullet(direction + offset/2 ,viewAngle );
                fireBullet(direction - offset/2,viewAngle );
                fireBullet(direction,viewAngle);
                }
            }
        
        }
        if(pistol==false && shotgun == true && ak47== false && pickIce == false && pickBatt == true && pickFire == false){
        if(ammo > 0 && shootTimerShotgun <=0){
                if (Input.GetMouseButtonDown(0)){
                bulletPace = 10;
                shootTimerShotgun = 1;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                Vector2 offset = Vector2.right ;
                // /int offset = difference / distance + 10;
                direction.Normalize();
                AudioSource.PlayClipAtPoint (sparkShot, transform.position);
                fireBullet(direction + offset/2 ,viewAngle );
                fireBullet(direction - offset/2,viewAngle );
                fireBullet(direction,viewAngle);
                }
            }

        
        
        }
        if(pistol==false && shotgun == true && ak47== false && pickIce == false && pickBatt == false && pickFire == true){
        if(ammo > 0 && shootTimerShotgun <=0){
                if (Input.GetMouseButtonDown(0)){
                bulletPace = 10;
                shootTimerShotgun = 1;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                Vector2 offset = Vector2.right ;
                // /int offset = difference / distance + 10;
                direction.Normalize();
                AudioSource.PlayClipAtPoint (fireShot, transform.position);
                fireBullet(direction + offset/2 ,viewAngle );
                fireBullet(direction - offset/2,viewAngle );
                fireBullet(direction,viewAngle);
                }
            }
        }
    
    
    
        
     if(pistol==false && shotgun == true && ak47==false){
        if(ammo > 0 && shootTimerShotgun <=0){
                if (Input.GetMouseButtonDown(0)){
                bulletPace = 10;
                shootTimerShotgun = 1;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                Vector2 offset = Vector2.right ;
                // /int offset = difference / distance + 10;
                direction.Normalize();
                AudioSource.PlayClipAtPoint (shotgunShot, transform.position);
                fireBullet(direction + offset/2 ,viewAngle );
                fireBullet(direction - offset/2,viewAngle );
                fireBullet(direction,viewAngle);
                }
            }
     }

    //AK Script

     if(pistol==false && shotgun == false && ak47==true){
        if(ammo > 0 && shootTimerAK <=0){
            if (Input.GetMouseButton(0)){
                shootTimerAK= 1;
                bulletPace = 10;
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                fireBullet(direction,viewAngle);
            }
        }
    }

     if (Input.GetButton("Fire1")){
         particleEmitter.Play();
     }
     else if (Input.GetButtonUp("Fire1")){
         particleEmitter.Stop();
 }

        
    }

    
    IEnumerator Reset(){
        yield return new WaitForSeconds(3);
        counter = 0;
        limit = false;
        
    }

    void fireBullet(Vector2 direction, float viewAngle){
        if (bulletNormal == true && pickIce == false && pickBatt == false && pickFire == false){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = gunFire.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(b, 1.0f);
        ammo = ammo + 1;
        
        }
        
        if(bulletNormal == true && pickIce == true && pickBatt == false && pickFire == false){
        GameObject frost = Instantiate(frostBullet) as GameObject;
        bulletPace = 5;
        frost.transform.position = gunFire.transform.position;
        frost.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        frost.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(frost, 2.0f);   
        }
        
        if(bulletNormal == true && pickIce == false && pickBatt == true && pickFire == false){
        bulletPace = 5;
        GameObject lightning = Instantiate(lightningBullet) as GameObject;
        lightning.transform.position = gunFire.transform.position;
        lightning.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        lightning.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(lightning, 2.0f);   
        }

         
        if(bulletNormal == true && pickIce == false && pickBatt == false && pickFire == true){
        bulletPace = 5;
        GameObject ember = Instantiate(emberBullet) as GameObject;
        ember.transform.position = gunFire.transform.position;
        ember.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        ember.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(ember, 2.0f);   
        }
    }

    
}
