using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    
    private Transform healthBar;
    

    // Find the bar gameObject using a tag
    void Start()
    {
         healthBar = transform.Find("Bar");
        
       
    }

    //Used to set the size of the health bar
    public void SetSize(float sizeNormalized){
        healthBar.localScale = new Vector3 (sizeNormalized,1f);
    }

}
    // Update is called once per frame
    
