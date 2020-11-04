using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteroidDuck : MonoBehaviour
{
    public GameObject mainPlayer;
    //Enemy hit gameobjects to appear onHit
    public GameObject feather;
    public GameObject frostHit;
    public GameObject lightningHit;
    public GameObject fireHit;
    public GameObject sparkHit;

    //Audio Clips for hit sounds
     public AudioClip deathClip;
    public AudioClip iceHit;
    public AudioClip sparksHit;
    
    public AudioClip flameHit;


    public GameObject knife;
    public GameObject knifeLaunch;

    private SpriteRenderer mySpriteRenderer;

    private bool icePick = false;
     private bool battPick = false;
     private bool firePick = false;
     private bool hitBoss = false;

    // Variables to control damage dealt and defences
    public float bossPistolDamage = 15;
    public float bossIceDamage = 10;
    public float bossFireDamage = 10;
    public float bossLightningDamage = 10;
    public float bossArmor = 10;
    public float bossIceArmor = 0;
    public float bossLightningArmor = 0;
    public float bossFireArmor = 0;

    //Speed And Chase & Attack Range
    public float bossSpeed;
    public float bossAttackRange = 3f;
    
    public float bossMeeleRange = 1f;
    public float knifeSpeed = 5f;
    public float bossHealth = 100;

    public float chaseRange;
    private float lastAttackTime;
    public float attackDelay;

    //Used to Access Player control's variable of the currently held bullet for hit effects
    public PlayerController boolean;

    //Used to locate Main Players position
    private Transform target;

    Animator attackAnim;

    
    // Start is called before the first frame update
    void Start()
    {
        
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        attackAnim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {   

        icePick = boolean.icePicked;
        battPick = boolean.batteryPicked;
        firePick = boolean.emberPicked;

        if(bossHealth <= 0){
        //counter.points = counter.points + duckPoints;
        Death();   
        }
        
        //Check the distance between Boss & Player
        float dist = Vector3.Distance(transform.position, target.position);

        //If the distance is less than the chase range chase player towards player's position
        if(dist < chaseRange){
            transform.position = Vector2.MoveTowards(transform.position, target.position, bossSpeed * Time.deltaTime);
             attackAnim.SetTrigger("Walk");
             attackAnim.ResetTrigger("Idle");
        }
        else{
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Walk");
            
        }

        if (dist <= bossAttackRange && dist >= bossMeeleRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg + 180f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90* Time.deltaTime);
            attackAnim.SetTrigger("Attack Ranged");
            attackAnim.ResetTrigger("Idle");
            
            //Check time between last shots through attacktime and delay to make delayed shots
            if (Time.time > lastAttackTime + attackDelay){
                    //Raycast to check whether player is within sight of the taget
                    RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, bossAttackRange);
                    // Check if ray has hit anything and return what it had hit
                    //if(hit.transform == target){
                        //If it Hit the player - fire the spear
                        float distance = targetDir.magnitude;
                        Vector2 direction = targetDir / distance;
                        GameObject bc = Instantiate(knife) as GameObject;
                        bc.transform.position = knifeLaunch.transform.position;
                        bc.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
                        bc.GetComponent<Rigidbody2D>().velocity = direction * knifeSpeed;
                         Destroy(bc, 4.0f);
                         //b.transform.position = gunFire.transform.position;
                         lastAttackTime =  Time.time;

                   //}
                }
        }
         else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Attack Ranged");
        }

         if (dist <= bossAttackRange && dist <= bossMeeleRange)
        {
            attackAnim.SetTrigger("Attack Melee");
            attackAnim.ResetTrigger("Walk");
        }
        else
        {
           attackAnim.SetTrigger("Walk");
            attackAnim.ResetTrigger("Attack Melee");
        }

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
    }

     void OnCollisionEnter2D(Collision2D col) {

       if (col.gameObject.CompareTag("LightningBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
             AudioSource.PlayClipAtPoint (sparksHit, transform.position);
            bossHealth = bossHealth - (bossLightningDamage - bossLightningArmor);
            hitBoss = true; 
            }

        if (col.gameObject.CompareTag("IceBullet")){
                Destroy (col.gameObject);
                //Destroy (gameObject);
                bossHealth = bossHealth - (bossIceDamage - bossIceArmor);
                bossSpeed = bossSpeed - 0.1f;
                hitBoss = true; 
            }

        if (col.gameObject.CompareTag("Bullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            bossHealth = bossHealth - (bossPistolDamage - bossArmor);
            hitBoss = true;
        }

        if (col.gameObject.CompareTag("FireBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            bossHealth = bossHealth - (bossFireDamage - bossFireArmor);
            hitBoss = true; 
        }

       
        
         

        if (col.gameObject.CompareTag("Player"))
        {
            attackAnim.SetTrigger("Attack Melee");
            attackAnim.ResetTrigger("Walk");
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
