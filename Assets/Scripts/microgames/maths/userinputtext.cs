using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class userinputtext : MonoBehaviour
{
    public static string displayText;
    bool startCheck = false;
    bool running = false;
    TMP_Text userInputDisplay;
    float count;

    void Start()
    {
        userInputDisplay = GetComponent<TMP_Text>();
    }
    public void Enter()
    {
        startCheck = true;
        count = Time.time + 3;
    }
    void Update()
    {
        if (startCheck) //If enter was pressed
        {
            int userNum;
            if (displayText != "")
                userNum = int.Parse(displayText);
            else
                userNum = -1;
            if (userNum == mathtext.result)
            {
                countdown.countdownEnabled = false;
                userInputDisplay.SetText("CORRECT!");
                if (count <= Time.time && !running)
                {
                    nextmicrogame.ProbabiltyMesser(mathtext.difficulty);
                    mathtext.difficulty += 1;
                    nextmicrogame.transition(true);
                    running = true;

                }
            }

            else
            {
                countdown.countdownEnabled = false;
                userInputDisplay.SetText("WRONG! ITS " + mathtext.result);
                if (count <= Time.time && !running)
                    {
                        nextmicrogame.transition(false);
                        running = true;
                    }
                }
            }
        }
    }

