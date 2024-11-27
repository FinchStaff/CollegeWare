using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    TMP_Text text;
    //Whether countdown is enabled 
    public static bool countdownEnabled;  
    //whether running out of time is actually a winstate, false by default
    public bool winState = false;
    public static float count; //The count addition, edited by other scripts
    public float maincount; //The count defined in the inspector
    bool running = false;
    float endcount;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        countdownEnabled = true;
        //Get the text component of self
        text = gameObject.GetComponent<TMP_Text>();

        endcount = Time.time + maincount + count; //get the end time needed
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownEnabled){
            //if time is larger than or equal to end count
            if (Time.time >= endcount) 
            {
                if (!running){
                    if (!winState)
                        nextmicrogame.transition(false); //if ran out of time, lose
                    else
                        nextmicrogame.transition(true, true);
                }
                running = true;
            }
            else
            {
                // works like this, say time is 30, then it will be 40 - 30 = 10, then 40-31 = 9
                text.SetText(Convert.ToString(Math.Floor(endcount - Time.time))); 
            }
        }
    }
}
