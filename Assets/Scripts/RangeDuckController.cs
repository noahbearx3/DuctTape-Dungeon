using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDuckController : MonoBehaviour
{
    public GameObject mainPlayer;
    Animator attackAnim;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        attackAnim = gameObject.GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        // Calculates the difference between the mainPlayer, and the Duck
        float dist = Vector3.Distance(mainPlayer.transform.position, transform.position);

        // Changes the animation depending on the distance
        if (dist <= 3)
        {
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Idle");
        } else
        {
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Attack");
        }

        // Calculats where the player is compared to the duck
        //  << 0.0 means he is on the left side of the duck
        // >> 0.0 means he is on the right side of the duck
        // Flips the sprite when he is on the right side, and flips it back when he's on the left side again
        var relativePoint = transform.InverseTransformPoint(mainPlayer.transform.position);
        if (relativePoint.x < 0.0)
        {
            mySpriteRenderer.flipX = false;
        }
        else if (relativePoint.x > 0.0)
        {
            mySpriteRenderer.flipX = true;
        }           
                
        












    }

    
}
