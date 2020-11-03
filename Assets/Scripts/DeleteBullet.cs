using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{

    public AudioClip hitWall;
    public GameObject wallHit;

    public bool bulletHitWall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //Check if bullet hit wall
        if(bulletHitWall == true){
            GameObject rubble = Instantiate(wallHit) as GameObject;
            
            rubble.transform.position = transform.position;
            Destroy(rubble, 0.2f);
            bulletHitWall = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        // If Bullet collides with wall destroy bullet and set bulletHitWall to true
        if (col.gameObject.CompareTag("Bullet")){
             bulletHitWall = true;
             AudioSource.PlayClipAtPoint (hitWall , transform.position);
            Destroy (col.gameObject);
           
        }

         if (col.gameObject.CompareTag("LightningBullet")){
             bulletHitWall = true;
             AudioSource.PlayClipAtPoint (hitWall , transform.position);
            Destroy (col.gameObject);
           
        }

         if (col.gameObject.CompareTag("IceBullet")){
             bulletHitWall = true;
             AudioSource.PlayClipAtPoint (hitWall , transform.position);
            Destroy (col.gameObject);
           
        }
    }

    
       
            

}
