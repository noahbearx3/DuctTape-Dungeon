using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    public GameObject iceBullet;
    public GameObject lightningBullet;
    public CameraShake shake;
    public GameObject feather;
    public float pistolDamage = 15;
    public float duckArmor = 10;
    public float duckIceArmor = 0;
    public float duckLightningArmor = 0;
    public float duckFireArmor = 0;
    public float iceDamage = 10;
    public float fireDamage = 10;
    public float lightningDamage = 10;

    

    public GameObject frostHit;
    public GameObject lightningHit;
    public GameObject duckEnemy;

    private Vector3 duckPosition;
    public GameObject bulletHit;

    EnemyController icePicked;

    public float enemySpeed;

    private bool hitDuck = false;

    private bool icePick = false;
    private bool battPick = false;
    [SerializeField] private float chaseRange = 4f;

    private Transform target;

    public PlayerController boolean;
    
    // /AudioSource audio;
    public AudioClip deathClip;
    public AudioClip iceHit;
    public AudioClip sparkHit;

    public GameObject mainPlayer;
    private SpriteRenderer mySpriteRenderer;


    Animator attackAnim;
    // Start is called before the first frame update
    void Start()
    {
         
        // /boolean = GetComponent<PlayerController>();
        enemyHealth = 100;
        attackAnim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //audio = GetComponent<AudioSource>();
        
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        

        icePick = boolean.icePicked;
        battPick = boolean.batteryPicked;

        duckPosition = duckEnemy.transform.position;
        
        if(enemyHealth <= 0){

           Death();
            
            
        }

        if (hitDuck == true && icePick == false && battPick == false ){
            GameObject h = Instantiate(bulletHit) as GameObject;
            h.transform.position = transform.position;
            Destroy(h, 0.2f);
            
            hitDuck = false;
        }

        if (hitDuck == true && icePick == true && battPick == false){
            GameObject frost = Instantiate(frostHit) as GameObject;
            AudioSource.PlayClipAtPoint (iceHit, transform.position);
            frost.transform.position = transform.position;
            Destroy(frost, 0.2f);
            hitDuck = false;
        }

        if (hitDuck == true && icePick == false && battPick == true ){
            GameObject spark = Instantiate(lightningHit) as GameObject;
            spark.transform.position = transform.position;
            Destroy(spark, 0.2f);
            hitDuck = false;
        }

        float dist = Vector3.Distance(transform.position, target.position);


        if(dist < chaseRange){
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
            attackAnim.SetTrigger("Walk");
            attackAnim.ResetTrigger("Idle");
        } else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Walk");
        }

        // Calculats where the player is compared to the duck
        //  << 0.0 means he is on the left side of the duck
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





    }
          
     void FixedUpdate() {
        lightningBullet = GameObject.FindGameObjectWithTag("LightningBullet");
         iceBullet = GameObject.FindGameObjectWithTag("IceBullet");
         bullet = GameObject.FindGameObjectWithTag("Bullet");
         
         
        
    }
   void OnCollisionEnter2D(Collision2D col) {

       if (col.gameObject.CompareTag("LightningBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
             AudioSource.PlayClipAtPoint (sparkHit, transform.position);

            enemyHealth = enemyHealth - (lightningDamage - duckLightningArmor);
            
            hitDuck = true; 
            shake.ShakeCamera(); 
            }

        if (col.gameObject.CompareTag("IceBullet")){
                Destroy (col.gameObject);
                //Destroy (gameObject);
                enemyHealth = enemyHealth - (iceDamage - duckIceArmor);
                enemySpeed = enemySpeed - 0.1f;
                hitDuck = true; 
                shake.ShakeCamera(); 
            
            }

        if (col.gameObject.CompareTag("Bullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            enemyHealth = enemyHealth - (pistolDamage - duckArmor);
            hitDuck = true; 
            shake.ShakeCamera(); 
            
            

        }

       
        
         

        if (col.gameObject.CompareTag("Player"))
        {
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Walk");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attackAnim.ResetTrigger("Attack");
        attackAnim.SetTrigger("Walk");
    }

    void Death(){
        AudioSource.PlayClipAtPoint (deathClip, transform.position);
        GameObject f = Instantiate(feather) as GameObject;
        Destroy (gameObject);
        f.transform.position = transform.position;
        Destroy(f, 0.1f);
    }
}
