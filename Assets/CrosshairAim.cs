using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairAim : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 crosshairMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = crosshairMousePos;
    }
}
