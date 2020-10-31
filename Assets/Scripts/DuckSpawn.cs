using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawn : MonoBehaviour
{
    public List<GameObject> duckEnemies = new List<GameObject>();
    public int randomEnemy;
    public PlayerController boolean;


    // Start is called before the first frame update
    void Start()
    {

        // Generates a random duck from the arra
        randomEnemy = Random.Range(0, duckEnemies.Count);
        
        Instantiate(duckEnemies[randomEnemy], transform.position, Quaternion.identity);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
