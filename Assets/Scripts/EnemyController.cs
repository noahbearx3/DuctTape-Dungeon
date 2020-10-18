using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    public CameraShake shake;

    public GameObject bulletHit;

    public float speed;

    private Transform target;

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
        
        if(enemyHealth == 0){
            
            Destroy (gameObject);
        }
        //if(Vector2.Distance(transform.position, target.position) > 3){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    //}
}
          
     void FixedUpdate() {
         
         bullet = GameObject.FindGameObjectWithTag("Bullet");
        
    }
   void OnCollisionEnter2D(Collision2D col) {

        
        if (col.gameObject.CompareTag("Bullet")){
            Destroy (col.gameObject);
            //Destroy (gameObject);
            enemyHealth = enemyHealth - 25;
            shake.ShakeCamera(); 

        }

        if (col.gameObject.CompareTag("Player"))
        {
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Idle");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attackAnim.ResetTrigger("Attack");
        attackAnim.SetTrigger("Idle");
    }
}
