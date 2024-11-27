using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject disabledParent, timer;
    SpriteRenderer objsprite; //SpriteRenderer is a class but it works similar to a data type here
    public Sprite[] sprites = new Sprite[3]; //makes an empty array with length of 3 that you put sprites into
    public static int num;
    Vector2 screenbounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objsprite = gameObject.GetComponent<SpriteRenderer>(); //makes objsprite set to this objects sprite renderer
        num = Random.Range(0,3);
        objsprite.sprite = sprites[num]; //makes the sprite renderer's sprite equal to the sprite in the array
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)); //screenbounds x coords is equal to the right screen bound and its y coords is equal to the top screen bound
        speed = 0.1f*(RememberLogicScript.difficulty+1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(transform.position.x + speed,transform.position.y);
        if(transform.position.x > (screenbounds.x-2.5/*multiply screenbounds.x by -1 to get the left screen bound*/))
        {
            gameObject.SetActive(false);
            disabledParent.SetActive(true);
            timer.SetActive(true);
        }
    }
}
