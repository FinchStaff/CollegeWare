
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System;
using TMPro;
public class mathtext : MonoBehaviour
{
    [SerializeField] TMP_Text equation;
    public static int difficulty;
    bool type;
    int num1, num2; // num1 -/+ num2 = result
    public static int result;
    // Start is called before the first frame update
    void Awake()
    {
        userinputtext.displayText = "";
        //Generate a random bool 0 or 1, then also clamp the difficulty between 0 and 5
        type =  Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
        difficulty = Mathf.Clamp(difficulty, 0, 2);

        //Depending on difficulty, as which is decided on how many times this microgame has popped up, change range of values
        switch (difficulty)
        {
            case 0:
                num1 = UnityEngine.Random.Range(10,20);
                num2 = UnityEngine.Random.Range(0,10);
                break;
            case 1:
                num1 = UnityEngine.Random.Range(10,50);
                num2 = UnityEngine.Random.Range(4,10);
                break;
            case 2:
                num1 = UnityEngine.Random.Range(50,100);
                num2 = UnityEngine.Random.Range(20,50);
                break;
        }

        //Add the the difficulty to the timer
        countdown.count = difficulty*5;


        //type true num1 - num2
        if(type)
        {
            result = num1 - num2;
            equation.SetText(num1 + " - " + num2 + " = ?");
        }
        //type false num1 + num2
        else
        {
            result = num1 + num2;
            equation.SetText(num1 + " + " + num2 + " = ?");
        }
        
    }

    public bool checkPlayerAnswer(int playerAns)
    {
        if (result == playerAns)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
