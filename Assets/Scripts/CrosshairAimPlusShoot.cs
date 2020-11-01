using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAimPlusShoot : MonoBehaviour
{

    public Camera cam;
    public GameObject bullet;

    public GameObject frostBullet;

    public GameObject lightningBullet;

    public float bulletPace = 60f;

    private bool pickIce;
    private bool pickBatt;
    private bool shotgun = false;
    private bool ak47 = false;

    private bool pistol = true;

    private Vector3 target;
    public GameObject player;
    public GameObject gunFire;

    CrosshairAimPlusShoot icePicked;    
    public Rigidbody2D rb;

    private Vector2 crosshairMousePos;

    public bool bulletNormal = true;

    public PlayerController boolean;   
    AudioSource audio;


     public ParticleSystem particleEmitter;
     //private ParticleAnimator particleAnimator;
     

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
         audio = GetComponent<AudioSource>();
        //particleEmitter = GameObject.Find("Particle System").GetComponent<ParticleSystem>().Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        pickIce = boolean.icePicked;
        pickBatt = boolean.batteryPicked;
        shotgun = boolean.shotgunPicked;
        ak47 = boolean.ak47Picked;
         Debug.Log(pickIce);
            Debug.Log(pickBatt);

        
        
        if(shotgun){
            pistol = false;
            shotgun = true;
            ak47 = false;
            Debug.Log(bulletNormal);
            Debug.Log(ak47);
            Debug.Log(shotgun);
            
        }
          if(ak47){
            pistol = false;
            shotgun = false;
            ak47 = true;
            Debug.Log(bulletNormal);
            Debug.Log(ak47);
            Debug.Log(shotgun);
        }
        
        crosshairMousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = crosshairMousePos;
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Vector3 difference = target - player.transform.position;

        Vector2 lookDir = crosshairMousePos - rb.position;
        // Using Atan to calculate the x-axis to the direcokDir.x) * Mathf.Rad2Deg - 90f;
         float viewAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        
    if(pistol==true && shotgun == false && ak47==false){
        if (Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
             audio.Play(0);
            fireBullet(direction,viewAngle);
        }
    
    }
        
     if(pistol==false && shotgun == true && ak47==false){
        if (Input.GetMouseButtonDown(0)){
            bulletPace = 10;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            Vector2 offset = Vector2.right ;
            // /int offset = difference / distance + 10;
            direction.Normalize();
            fireBullet(direction + offset/2 ,viewAngle );
            fireBullet(direction - offset/2,viewAngle );
            fireBullet(direction,viewAngle);
        }
    }

     if(pistol==false && shotgun == false && ak47==true){
        if (Input.GetMouseButton(0)){
            bulletPace = 10;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction,viewAngle);
        }
    }

     if (Input.GetButton("Fire1")){
         particleEmitter.Play();
     }
     else if (Input.GetButtonUp("Fire1")){
         particleEmitter.Stop();
 }

        
    }

    

    void fireBullet(Vector2 direction, float viewAngle){
        if (bulletNormal == true && pickIce == false && pickBatt == false){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = gunFire.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(b, 1.0f);
        
        }
        
        if(bulletNormal == true && pickIce == true && pickBatt == false){
        GameObject frost = Instantiate(frostBullet) as GameObject;
        frost.transform.position = gunFire.transform.position;
        frost.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        frost.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(frost, 2.0f);   
        }
        
        if(bulletNormal == true && pickIce == false && pickBatt == true){
        bulletPace = 5;
        GameObject lightning = Instantiate(lightningBullet) as GameObject;
        lightning.transform.position = gunFire.transform.position;
        lightning.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        lightning.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(lightning, 2.0f);   
        }
    }

    
}
