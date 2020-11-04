using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteroidDuck : MonoBehaviour
{

    //Enemy hit gameobjects to appear onHit
    public GameObject frostHit;
    public GameObject lightningHit;
    public GameObject fireHit;

    // Variables to control damage dealt and defences
    public float bossPistolDamage = 15;
    public float bossIceDamage = 10;
    public float bossFireDamage = 10;
    public float bossLightningDamage = 10;
    public float bossArmor = 10;
    public float bossIceArmor = 0;
    public float bossLightningArmor = 0;
    public float bossFireArmor = 0;

    //Speed And Chase & Attack Range
    public float bossSpeed;
    public float bossAttackRange = 3f;

    public float chaseRange;
    private float lastAttackTime;
    public float attackDelay;
    // Start is called before the first frame update
    void Start()
    {
        icePick = boolean.icePicked;
        battPick = boolean.batteryPicked;
        firePick = boolean.emberPicked;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        
        if(dist < chaseRange){
            transform.position = Vector2.MoveTowards(transform.position, target.position, mallardSpeed * Time.deltaTime);
             //attackAnim.SetTrigger("Walk");
             //attackAnim.ResetTrigger("Idle");
        }
        else{
            attackAnim.SetTrigger("Idle");
            attackAnim.ResetTrigger("Walk");
        }

        if (dist < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y,targetDir.x) * Mathf.Rad2Deg + 180f;
            Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90* Time.deltaTime);
            attackAnim.SetTrigger("Attack");
            attackAnim.ResetTrigger("Idle");
            
            //Check to see if player is within attack range and makes Boss attack
            if (Time.time > lastAttackTime + attackDelay){
                    //Raycast to check whether player is within sight of the taget
                    RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up, attackRange);
                    // Check if ray has hit anything and return what it had hit
                    //if(hit.transform == target){
                        //If it Hit the player - fire the spear
                        float distance = targetDir.magnitude;
                        Vector2 direction = targetDir / distance;
                        GameObject spear = Instantiate(spearObject) as GameObject;
                        spear.transform.position = spearFire.transform.position;
                        spear.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
                        spear.GetComponent<Rigidbody2D>().velocity = direction * spearSpeed;
                         Destroy(spear, 1.0f);
                         //b.transform.position = gunFire.transform.position;
                         lastAttackTime =  Time.time;

                  //  }
            }

        } 


    }
}
