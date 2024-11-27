using UnityEngine;
using UnityEngine.Android;

public class RememberLogicScript : MonoBehaviour
{
    public static int difficulty = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficulty = Mathf.Clamp(difficulty, 0,2);
    }
}
