using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDuckController : MonoBehaviour
{
    public GameObject mainPlayer;
    Animator attackAnim;
    private SpriteRenderer mySpriteRenderer;
    public GameObject spearObject;
    private Transform target;
    public float attackRange = 3f;
    public float chaseRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    public GameObject spearFire;

    public float spearSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        attackAnim = gameObject.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        // Calculates the difference between the mainPlayer, and the Duck
        float dist = Vector3.Distance(transform.position, target.position);

        // Changes the animation depending on the distance and checks if player is withinn attack range 
        if (dist < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90* Time.deltaTime);
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Idle");
            
            //Check to see if player is within attack range and makes duck attack
            if (Time.time > lastAttackTime + attackDelay){
                    //Raycast to check whether player is within sight of the taget
                    RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, attackRange);
                    // Check if ray has hit anything and return what it had hit
                    //if(hit.transform == target){
                        //If it Hit the player - fire the spear
                        float distance = targetDir.magnitude;
                        Vector2 direction = targetDir / distance;
                        GameObject spear = Instantiate(spearObject) as GameObject;
                        spear.transform.position = spearFire.transform.position;
                        spear.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
                        spear.GetComponent<Rigidbody2D>().velocity = direction * spearSpeed;
                         Destroy(spear, 1.0f);
                         //b.transform.position = gunFire.transform.position;
                         lastAttackTime =  Time.time;

                  //  }
            }

        } 
        
        else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Attack");
        }

        // Calculats where the player is compared to the duck
        // << 0.0 means he is on the left side of the duck
        // >> 0.0 means he is on the right side of the duck
        // Flips the sprite when he is on the right side, and flips it back when he's on the left side again
        var relativePoint = transform.InverseTransformPoint(mainPlayer.transform.position);
        if (relativePoint.x < 0.0)
        {
            mySpriteRenderer.flipX = false;
        }
        else if (relativePoint.x > 0.0)
        {
            mySpriteRenderer.flipX = true;
        }           
                
        


    //void Attack(){
        
      //  
     //   spear.transform.position = spear.transform.position;
     //   spear.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    //    spear.GetComponent<Rigidbody2D>().velocity = direction * bulletPace;
     //   Destroy(spear, 2.0f);
    


//    }






    }

    
}
