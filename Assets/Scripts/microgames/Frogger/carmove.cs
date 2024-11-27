using UnityEngine;

public class carmove : MonoBehaviour
{
    private Camera cam;
    int direction;
    private Vector2 screen;
    public float carspeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screen = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); //Convert the screen's height and width to WorldPoints
        if (transform.position.x < 0) {direction = 1;} //if on the right move left
        else {direction = -1;} //if on the left move right
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + carspeed*direction, transform.position.y);
    }

    void LateUpdate()
    {
        //if past either edge of the screen, despawn
        if (transform.position.x > screen.x + 3 || transform.position.x < (screen.x*-1) -3)
        {
            gameObject.SetActive(false);
        }
    }

    
}
