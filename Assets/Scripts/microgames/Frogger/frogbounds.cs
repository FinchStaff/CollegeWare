using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogbounds : MonoBehaviour
{

    private float objectWidth;
    private float objectHeight;
    

    Vector2 screenBounds;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the bounds of the screen
        screenBounds = difficulty.screenBounds;
        Debug.Log("Screen Bounds Frog Bounds: " + screenBounds);
        //Gets object size
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        transform.position = new Vector2(0, screenBounds.y*-1);
    }

    void LateUpdate()
    {
        //Gets the position of the player
        Vector3 screenpos = transform.position;
        //Clamps the players position to be on screen
        screenpos.x = Mathf.Clamp(screenpos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        screenpos.y = Mathf.Clamp(screenpos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = screenpos;
    }
}
