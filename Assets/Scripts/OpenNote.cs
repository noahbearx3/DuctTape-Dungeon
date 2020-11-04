using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenNote : MonoBehaviour
{
    public GameObject mainPlayer;
    bool reading = false;
    public Image note;


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

        if (dist <= 1.5)
        {
            if (Input.GetKeyDown(KeyCode.E))
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
