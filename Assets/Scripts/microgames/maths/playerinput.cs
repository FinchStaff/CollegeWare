using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class playerinput : MonoBehaviour
{
    [SerializeField] TMP_Text userInputDisplay;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText()
    {
        string selftext = gameObject.GetComponent<TMP_Text>().text;
        userinputtext.displayText = userinputtext.displayText + selftext;
        Debug.Log("Pressed");
        userInputDisplay.SetText(userinputtext.displayText);
        Debug.Log("Display "+ userinputtext.displayText);
    }

    
}
