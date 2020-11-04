using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private Transform Hands;
    public GameObject myPlayer;
    public GameObject pistol;
    [SerializeField] private SpriteRenderer handsSprite;
    public float moveLeft = -1f;

    private void Start()
    {
       Hands = transform.Find("PlayerHands");
    }

    private void FixedUpdate()
    {

        Vector3 v3Pos;
        float fAngle;


        v3Pos = Camera.main.WorldToScreenPoint(myPlayer.transform.position);
        v3Pos = Input.mousePosition - v3Pos;
        fAngle = Mathf.Atan2(v3Pos.y, v3Pos.x) * Mathf.Rad2Deg +90f;
        if (fAngle < 0.0f) fAngle += 360.0f;
        transform.rotation = Quaternion.Euler(0f, 0f, fAngle);

        if(fAngle <= 360 && fAngle >= 180)
        {
            moveLeft = -1f;
            FlipHands (moveLeft);

        }
        else
        {
            FlipHands(1f);
        }



    }


    public void FlipHands (float moveLeft)
    {
        Hands.localScale = new Vector3(moveLeft, 1f);

    }

}