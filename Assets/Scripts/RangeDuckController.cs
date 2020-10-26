using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDuckController : MonoBehaviour
{
    public GameObject mainPlayer;
    Animator attackAnim;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        attackAnim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Round(Vector3.Distance(mainPlayer.transform.position, transform.position));
       // print("Distance to other: " + dist);

        if (dist <= 3)
        {
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Idle");
        } else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Attack");
        }

    }

    
}
