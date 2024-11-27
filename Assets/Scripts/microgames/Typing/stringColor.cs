using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class stringColor : MonoBehaviour
{
    static TMP_Text text;
    static string textString, completed, uncompleted, wholeString, colSelected;
    public static string selected;
    static bool running;
    static int stringIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        stringIndex = 0; //Resets stringIndex
        text = gameObject.GetComponent<TMP_Text>(); //Gets the text thingy, y'know, the text that is texty or something
        textString = typingDifficulty.selectedString; //gets the string
        selected = textString.Substring(0, 1); //Then gets the first character
        uncompleted = textString.Substring(1, textString.Length - 1); //then gets whatever is after that
        colSelected = "<color=#0000FF>"+selected+"</color>"; //Adds blue to it
        wholeString = colSelected + uncompleted; //then it does some errr, it adds the color
        text.SetText(wholeString); //puts it out into the big wide screen
    }

    public static void updateText()
    {
        stringIndex++;//increment the index
        Debug.Log("stringIndex: " + stringIndex + "textlength: " + textString.Length); 
        if (stringIndex == textString.Length && !running) //if index is le same as the lenght
        {
            nextmicrogame.ProbabiltyMesser(typingDifficulty.difficulty);
            typingDifficulty.difficulty += 1;
            nextmicrogame.transition(true);
            running = true;
            Debug.Log("NO TEXT!!!");
        }
        else{
            selected = textString.Substring(stringIndex, 1); //gets the selected character
            uncompleted = textString.Substring(stringIndex + 1, textString.Length - stringIndex - 1); //gets everything after
            completed = textString.Substring(0, stringIndex); //Get everything before that
            completed = "<color=#ffff00>"+completed+"</color>"; //Add color to completed
            colSelected = "<color=#0000FF>"+selected+"</color>"; //add color to selected
            wholeString = completed + colSelected + uncompleted;  //adds them all together
            text.SetText(wholeString); //Outputs
        }
    }
}
