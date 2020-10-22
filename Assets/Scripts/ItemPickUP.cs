using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUP : MonoBehaviour
{
    private InventorySystem inventory;
    public GameObject itemButton;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

     void OnTriggerEnter2D(Collider2D other) {

         if(other.CompareTag("Player")) {
            
            for (int i = 0; i < inventory.slots.Length; i++)
         {
             if(inventory.invFull[i] == false){
                 inventory.invFull[i] = true;
                 Instantiate(itemButton, inventory.slots[i].transform, false);
                 Destroy(gameObject);
                 break;
             }
         }

         }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
