using UnityEngine;

public class hand : MonoBehaviour
{
    public static bool pressing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            gameObject.transform.localScale = new Vector2(1.4f, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector2(1, 1);
        }
    }
}
