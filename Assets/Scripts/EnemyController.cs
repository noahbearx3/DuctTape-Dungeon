using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    public CameraShake shake;
    public GameObject feather;

    public GameObject frostHit;
    public GameObject duckEnemy;

    private Vector3 duckPosition;
    public GameObject bulletHit;

    EnemyController icePicked;

    public float speed;

    private bool hitDuck = false;

    private bool icePick = false;

    private Transform target;

    public PlayerController boolean;

    

    Animator attackAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100;
        attackAnim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        

    }

    // Update is called once per frame
    void Update()
    {
        icePick = boolean.icePicked;

        duckPosition = duckEnemy.transform.position;
        
        if(enemyHealth == 0){
            
            Destroy (gameObject);
            GameObject f = Instantiate(feather) as GameObject;
            f.transform.position = transform.position;
            Destroy(f, 0.1f);
        }

        if (hitDuck == true && icePick == true ){
            GameObject frost = Instantiate(frostHit) as GameObject;
            frostHit.transform.position = transform.position;
            Destroy(frostHit, 0.2f);
            
        }

        if (hitDuck == true && icePick == false ){
            GameObject h = Instantiate(bulletHit) as GameObject;
            h.transform.position = transform.position;
            Destroy(h, 0.2f);
            hitDuck = false;
        }

        

        if(Vector2.Distance(transform.position, target.position) < 5){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            attackAnim.SetTrigger("Walk");
            attackAnim.ResetTrigger("Idle");
        } else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Walk");
        }
}
          
     void FixedUpdate() {
         
         bullet = GameObject.FindGameObjectWithTag("Bullet");
        
    }
   void OnCollisionEnter2D(Collision2D col) {

        
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
