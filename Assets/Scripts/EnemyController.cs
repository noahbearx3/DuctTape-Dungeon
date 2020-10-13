using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    public CameraShake shake;

    Animator attackAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100;
        attackAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyHealth == 0){
            
            Destroy (gameObject);
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
