using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitandrun : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // On keypressed
    void OnGUI()
    {        
        Event Code = Event.current;
        if (Code.isKey && Code.character != '\0')
            Debug.Log(Code.character);
    }
}
