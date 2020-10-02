using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyHealth;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100;
       
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
            Destroy(bullet);
            enemyHealth = enemyHealth - 25;
            
            
        }
        
    }
}
