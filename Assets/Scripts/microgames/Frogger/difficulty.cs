using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{
    public static int frogdifficulty;
    public static Vector2 screenBounds;
    //Run this script before every other script
    void Awake()
    {
        //Output some random garbage to the log, this was for debugging things
        Debug.Log(Screen.width + " Screen Width " + Screen.height + " Screen height");
        Debug.Log(frogdifficulty + "Before Diff");

        //Clamp difficulty between 0 and 2
        frogdifficulty = Mathf.Clamp(frogdifficulty, 0, 2);

        //Switch depending on difficulty, then set camera size
        switch (frogdifficulty)
        {
            case 0:
                Camera.main.orthographicSize = 5;
                break;
            case 1:
                Camera.main.orthographicSize = 7;
                break;
            case 2:
                Camera.main.orthographicSize = 10;
                break;
        }
        Debug.Log(frogdifficulty + "after diff");
        //Create the screenbounds, this is important its here, as 7 hours of my time will tell you
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
