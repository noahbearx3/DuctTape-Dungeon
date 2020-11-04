using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{

    public GameObject mainPlayer;
    public GameObject computer;
    Animator openDoor;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        openDoor = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ComputerCode computerScript = computer.GetComponent<ComputerCode>();
        float dist = Vector3.Distance(transform.position, mainPlayer.transform.position);

        if (dist <= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(computerScript.codeReceived == true)
                {
                    openDoor.SetTrigger("CodeReceived");
                    Physics2D.IgnoreCollision(mainPlayer.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                }

            }
        }
    }
}
