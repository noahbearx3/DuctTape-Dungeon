using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerCode : MonoBehaviour
{
    public GameObject mainPlayer;
    bool reading = false;
    public Image note;
    public bool codeReceived;


    // Start is called before the first frame update
    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
        note.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, mainPlayer.transform.position);

        if (dist <= 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (reading)
                {
                    reading = false;
                    note.enabled = false;
                }
                else
                {
                    reading = true;
                    note.enabled = true;
                    codeReceived = true;
                }

            }
        }
        else
        {
            reading = false;
            note.enabled = false;
        }
    }
}
