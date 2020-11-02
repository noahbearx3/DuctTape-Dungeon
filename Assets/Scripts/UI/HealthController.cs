using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    
    [SerializeField] private HealthBarController bar;
    // Start is called before the first frame update
    public float health = 1f;
     void Start()
    {
     

     
    }

    
    void Update()
    {
        StartCoroutine("DoCheck");

       if (health <.3f) {
                if((health * 100f) % 3 == 0){
                    bar.SetColor(Color.white);
                }
                else {
                    bar.SetColor(Color.red);
                }
             }

              if(health>0f){
             
             bar.SetSize(health);
            // if health is below 30% flash the healthbar between red and white
             
         }
    }

    public IEnumerator DoCheck() {
    
     for(;;) {
         if(health>0f){
             
             bar.SetSize(health);
            // if health is below 30% flash the healthbar between red and white
             
         }
         yield return new WaitForSeconds(.1f);
     }
    }
}
