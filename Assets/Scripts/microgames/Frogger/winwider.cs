using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winwider : MonoBehaviour
{
    void Start()
    {
        //Converts the width of the screen to world points
        Vector2 width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*2, Screen.height));

        //Set position to the top edge of the screen and then make it as wide as the screen
        transform.position = new Vector2(0, width.y);
        transform.localScale = new Vector2(width.x, 1);
    }
}
