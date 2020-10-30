using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    public GameObject iceBullet;
    public GameObject lightningBullet;
    public CameraShake shake;
    public GameObject feather;

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

    private Transform target;

    public PlayerController boolean;


    public GameObject mainPlayer;
    private SpriteRenderer mySpriteRenderer;


    Animator attackAnim;
    // Start is called before the first frame update
    void Start()
    {
        boolean = GetComponent<PlayerController>();
        enemyHealth = 100;
        attackAnim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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
            
            Destroy (gameObject);
            GameObject f = Instantiate(feather) as GameObject;
            f.transform.position = transform.position;
            Destroy(f, 0.1f);
        }

        if (hitDuck == true && icePick == false && battPick == false ){
            GameObject h = Instantiate(bulletHit) as GameObject;
            h.transform.position = transform.position;
            Destroy(h, 0.2f);
            hitDuck = false;
        }

        if (hitDuck == true && icePick == true && battPick == false){
            GameObject frost = Instantiate(frostHit) as GameObject;
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
        if(Vector2.Distance(transform.position, target.position) < 5){
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
           iceBullet = GameObject.FindGameObjectWithTag("LightningBullet");
         iceBullet = GameObject.FindGameObjectWithTag("IceBullet");
         bullet = GameObject.FindGameObjectWithTag("Bullet");
         
         
        
    }
   void OnCollisionEnter2D(Collision2D col) {

       if (col.gameObject.CompareTag("LightningBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);

            enemyHealth = enemyHealth - 10;
            
            hitDuck = true; 
            shake.ShakeCamera(); 
            }

        if (col.gameObject.CompareTag("IceBullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            enemyHealth = enemyHealth - 20;
            enemySpeed = enemySpeed - 1;
            hitDuck = true; 
            shake.ShakeCamera(); 
            }

        if (col.gameObject.CompareTag("Bullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            enemyHealth = enemyHealth - 25;
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
}
