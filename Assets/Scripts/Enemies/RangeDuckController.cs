using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDuckController : MonoBehaviour
{
    public GameObject mainPlayer;

    public GameObject bullet;
    public GameObject iceBullet;
    public GameObject lightningBullet;
    public CameraShake shake;
    public GameObject feather;

    public GameObject frostHit;
    public GameObject lightningHit;
    public GameObject mallardEnemy;
    public GameObject bulletHit;
    public float mallardIceDamage = 7.5f;
    public EnemyController damageControl;
     AudioSource audio;
    public AudioClip deathClip;
    public AudioClip iceHit;
    public AudioClip sparkHit;
    Animator attackAnim;
    private SpriteRenderer mySpriteRenderer;
    public GameObject spearObject;
    private Transform target;
    public float attackRange = 3f;

    public float mallardSpeed = 2;
    public float chaseRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;
    private float mallardHealth;
    private bool hitMallard;
    public GameObject spearFire;

    public float spearSpeed = 5;
    private bool icePick = false;
     private bool battPick = false;

     public PlayerController boolean;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        attackAnim = gameObject.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mallardHealth = 100;
        
    }

    // Update is called once per frame
    void Update()
    {

        lightningBullet = GameObject.FindGameObjectWithTag("LightningBullet");
         iceBullet = GameObject.FindGameObjectWithTag("IceBullet");
         bullet = GameObject.FindGameObjectWithTag("Bullet");
         
        icePick = boolean.icePicked;
        battPick = boolean.batteryPicked;
        // Calculates the difference between the mainPlayer, and the Duck
        float dist = Vector3.Distance(transform.position, target.position);
        if(dist < chaseRange){
            transform.position = Vector2.MoveTowards(transform.position, target.position, mallardSpeed * Time.deltaTime);
             attackAnim.SetTrigger("Walk");
             attackAnim.ResetTrigger("Idle");
        }
        else{
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Walk");
        }
        // Changes the animation depending on the distance and checks if player is withinn attack range 
        if (dist < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg + 180f;
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

        if(mallardHealth <= 0){

           Death();
            
            
        }

        if(mallardSpeed <= 0.0f){
            mallardSpeed = mallardSpeed + 0.1f;
        }

        if (hitMallard == true && icePick == false && battPick == false ){
            GameObject h = Instantiate(bulletHit) as GameObject;
            h.transform.position = transform.position;
            Destroy(h, 0.2f);
            
            hitMallard = false;
        }

        if (hitMallard == true && icePick == true && battPick == false){
            GameObject frost = Instantiate(frostHit) as GameObject;
            AudioSource.PlayClipAtPoint (iceHit, transform.position);
            frost.transform.position = transform.position;
            Destroy(frost, 0.2f);
            hitMallard = false;
        }

        if (hitMallard == true && icePick == false && battPick == true ){
            GameObject spark = Instantiate(lightningHit) as GameObject;
            AudioSource.PlayClipAtPoint (sparkHit, transform.position);
            spark.transform.position = transform.position;
            Destroy(spark, 0.2f);
            hitMallard = false;
        }       
                
        
         
    }

    void OnCollisionEnter2D(Collision2D col) {

       if (col.gameObject.CompareTag("LightningBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);

            mallardHealth = mallardHealth - 10;
            
            hitMallard = true; 
            shake.ShakeCamera(); 
            }

        if (col.gameObject.CompareTag("IceBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            mallardHealth = mallardHealth - mallardIceDamage;
            mallardSpeed = mallardSpeed - 0.1f;
            hitMallard = true; 
            shake.ShakeCamera(); 
            }

        if (col.gameObject.CompareTag("Bullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            mallardHealth = mallardHealth - 25;
            hitMallard = true; 
            shake.ShakeCamera(); 
            
            

            }
        }
    void Death(){
        AudioSource.PlayClipAtPoint (deathClip, transform.position);
        GameObject f = Instantiate(feather) as GameObject;
        Destroy (gameObject);
        f.transform.position = transform.position;
        Destroy(f, 0.1f);
    }
}
