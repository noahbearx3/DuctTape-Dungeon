using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointSystem : MonoBehaviour
{
    //Point Text to access the text value of the UI Text Canvas
    public Text pointText;
    // Current Number of Points
    public int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Points text UI will be set to the current number of points
        pointText.text = "" + points;
    }
}
