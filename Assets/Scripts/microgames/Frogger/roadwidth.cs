using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadwidth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //Takes the screen width, and makes it so their own width is the same
        Vector2 roadwidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*2, 1));
        spriteRenderer.size = new Vector2(roadwidth.x, 1);
    }
}
