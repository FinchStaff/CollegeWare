using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typeDetect : MonoBehaviour
{
    [SerializeField] RectTransform hearts;
    int health = 3;
    bool running = false;

    void Update()
    {
        hearts.sizeDelta = new Vector2(100*health, hearts.sizeDelta.y);
        if (health <= 0 && !running)
        {
            nextmicrogame.transition(false);
            running = true;
        }
    }
    void OnGUI()
    {
        Event Code = Event.current;
        if (Code.isKey && Code.character != '\0')
        {
            Debug.Log(Code.character);
            Debug.Log(stringColor.selected + "to be typed");
            
            if (Convert.ToString(Code.character) != stringColor.selected)
            {
                health -= 1;
            }
            stringColor.updateText();
            Debug.Log(stringColor.selected + "after update");
        }
    }
}
