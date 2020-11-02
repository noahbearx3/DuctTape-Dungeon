using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] private HealthBarController bar;
    // Start is called before the first frame update
     void Start()
    {
     StartCoroutine("DoCheck");
    }

    
    void Update()
    {
       
    }

    IEnumerator DoCheck() {
    float health =1f;
     for(;;) {
         if(health>0){
             health -= .01f;
             bar.SetSize(health);
         }
         yield return new WaitForSeconds(.1f);
     }
    }
}
