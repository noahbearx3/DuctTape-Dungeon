using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAimPlusShoot : MonoBehaviour
{

    public Camera cam;
    public GameObject bullet;

    public float bulletPace = 60f;

    private Vector3 target;
    public GameObject player;
    public GameObject gunFire;
    
    public Rigidbody2D rb;

    private Vector2 crosshairMousePos;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        crosshairMousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = crosshairMousePos;
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Vector3 difference = target - player.transform.position;

        Vector2 lookDir = crosshairMousePos - rb.position;
        // Using Atan to calculate the x-axis to the direcokDir.x) * Mathf.Rad2Deg - 90f;
         float viewAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        Debug.Log(viewAngle);

        if (Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction,viewAngle);
        }

        
    }

    void fireBullet(Vector2 direction, float viewAngle){
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = gunFire.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, viewAngle);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
        Destroy(b, 2.0f);
        
    }

    
}
