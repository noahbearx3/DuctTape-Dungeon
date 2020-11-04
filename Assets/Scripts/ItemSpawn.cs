using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    private int randomItem;

    public GameObject mainPlayer;

    private void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, mainPlayer.transform.position);

        if (dist <= 1.5 && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);

            // Generates a random Item from the list
            randomItem = Random.Range(0, Items.Count);

            Instantiate(Items[randomItem], transform.position, Quaternion.identity);
        
        }
    }
}
