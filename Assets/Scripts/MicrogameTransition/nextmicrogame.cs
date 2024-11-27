using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextmicrogame : MonoBehaviour
{
    //Player health
    public static AsyncOperation sceneload;
    public static int health = 5;
    //The Microgames Done
    public static int MGdone = 0;
    
    //Use this to go to the transition screen
    /// <summary>
    /// Transition to the next microgame
    /// </summary>
    /// <param name="win">If the player won or not</param>
    public static void transition(bool win)
    {
        //if win is true, go to microgametransition
        if (win)
        {
            MGdone += 1;
            ProbabilityHandler.difficultyChange = true;
            sceneload = SceneManager.LoadSceneAsync(2);
            sceneload.allowSceneActivation = true;
        }
        //if win is false, health -1 and go to microgametransition
        else
        {
            ProbabilityHandler.difficultyChange = false;
            health -= 1;
            sceneload = SceneManager.LoadSceneAsync(2);
            sceneload.allowSceneActivation = true;
        }
    }
    /// <summary>
    /// Transition to the next microgame, but wait until sceneload.allowSceneActivation is = true
    /// </summary>
    /// <param name="win"></param>
    /// <param name="wait"></param>
    public static void transition(bool win, bool wait)
    {
        if (win)
        {
            MGdone += 1;
            sceneload = SceneManager.LoadSceneAsync(2);
            ProbabilityHandler.difficultyChange = true;
            sceneload.allowSceneActivation = false;
        }
        else if (!win)
        {
            ProbabilityHandler.difficultyChange = false;
            health -= 1;
            sceneload = SceneManager.LoadSceneAsync(2);
            sceneload.allowSceneActivation = false;
        }
    }
    public static int loadnext()
    {
        int loadID;
        int random;
        while (true){
            Debug.Log(SceneManager.sceneCountInBuildSettings);
            int scenecount = start.idArray.Length; //Number of scenes 
            random = Random.Range(0, scenecount); //Random number gen
            loadID = start.idArray[random];
            if (loadID != 0)
                return loadID;
            else {Debug.Log("TRIED TO RETURN ZERO!");}
        }
    }

    public static void ProbabiltyMesser(int diff)
    {
        if (diff != 2)
        {
            start.idArray[((SceneChances.previousMicrogame-6)*3) + diff] = 0;
        }
    }

    public static void gameOver()
    {
        SceneManager.LoadScene(2);
    }

    public static void gameWin()
    {
        SceneManager.LoadScene(3);
    }

    public static void menu()
    {
        SceneManager.LoadScene(1);
    }
}
