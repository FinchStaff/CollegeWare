
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typingDifficulty : MonoBehaviour
{
    public static int difficulty = 0;
    string[] easyStrings, mediumStrings, hardStrings;
    public static string selectedString;
    // Awake is called before the first frame update and start
    void Awake()
    {
        difficulty = Mathf.Clamp(difficulty, 0, 2);
        //All strings for the easy difficulty
        easyStrings = new string[]
        {"Hello", 
        "Typing", 
        "College", 
        "Maths",
        "Teacher"}; 

        //All strings for the medium difficulty
        mediumStrings = new string[]
        {"Hello World", 
        "Typing is fun", 
        "Integers are whole numbers",
        "Binary is base 2"};

        //All strings for the hard difficulty
        hardStrings = new string[]
        {"Console.WriteLine(\"hello world\");", 
        "My Train is delayed, I might be late.", 
        "This is just Mario teaches typing...",
        "Gotta type, GOT to type!",
        "Better Than You!"}; 

        //Random string selected
        int randomString;

        //Choose difficulty dependent string
        switch (difficulty)
        {
            case 0:
                randomString = Random.Range(0, easyStrings.Length);
                selectedString = easyStrings[randomString];
                break;
            case 1:
                randomString = Random.Range(0, mediumStrings.Length);
                selectedString = mediumStrings[randomString];
                break;
            case 2:
                randomString = Random.Range(0,hardStrings.Length);
                selectedString = hardStrings[randomString];
                countdown.count = 5;
                break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
