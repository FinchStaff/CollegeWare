using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class start : MonoBehaviour
{

    Button but;
    void Start()
    {
        //Gets self button component
        but = gameObject.GetComponent<Button>();
        //if pressed, run startpressed
        but.onClick.AddListener(startpressed);
    }
    public static int[] idArray;
    void startpressed()
    {
        
        //load microgametransition
        nextmicrogame.health = 5;
        nextmicrogame.MGdone = 0;
        //Reset difficultys
        difficulty.frogdifficulty = 0;
        mathtext.difficulty = 0;
        typingDifficulty.difficulty = 0;
        BirdScript.flapdifficulty = 0;
        buttonlogic.difficulty = 0;
        RememberLogicScript.difficulty = 0;
        EnemySpawner.difficulty = 0;

        //Create the id array
        idArray = new int[((SceneManager.sceneCountInBuildSettings-6) * 3)];
        for (int i = 6; i <= SceneManager.sceneCountInBuildSettings-1; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                idArray[j + (3 * (i - 6))] = i;
            }
        }
        foreach (int id in idArray) {Debug.Log(id); }
        
        

        SceneManager.LoadScene("microgametransition");
    }
    public static void PrintIDArray()
    {
        string wholeThing = "";
        foreach (int i in idArray)
        {
            wholeThing += Convert.ToString(i) + " ";
        }
        Debug.Log(wholeThing);
    }
}
