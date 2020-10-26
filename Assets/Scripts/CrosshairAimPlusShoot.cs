using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAimPlusShoot : MonoBehaviour
{

    public Camera cam;
    public GameObject bullet;

    public GameObject frostBullet;

    public float bulletPace = 60f;

    private bool pickIce;

    private Vector3 target;
    public GameObject player;
    public GameObject gunFire;

    CrosshairAimPlusShoot icePicked;    
    public Rigidbody2D rb;

    private Vector2 crosshairMousePos;

    public bool bulletNormal = true;

    public PlayerController boolean;   

     

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        pickIce = boolean.icePicked;
Debug.Log(pickIce);
        crosshairMousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = crosshairMousePos;
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Vector3 difference = target - player.transform.position;

        Vector2 lookDir = crosshairMousePos - rb.position;
        // Using Atan to calculate the x-axis to the direcokDir.x) * Mathf.Rad2Deg - 90f;
         float viewAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        
    
        if (Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction,viewAngle);
        
    }

        
    }

    void fireBullet(Vector2 direction, float viewAngle){
        if (bulletNormal == true && pickIce == false){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = gunFire.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(b, 2.0f);
        
        }

        if(bulletNormal == true && pickIce == true){
        GameObject frost = Instantiate(frostBullet) as GameObject;
        frost.transform.position = gunFire.transform.position;
        frost.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        frost.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(frost, 2.0f);   
        }
        
    }

    
}
