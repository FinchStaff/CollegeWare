using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class frogmovement : MonoBehaviour
{
    float inputWait;
    public float inputDelay;
    bool canMove = true, setTime = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if (Input.GetKeyDown("w"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                setTime = true;
                canMove = false;
            }
        }
            if (Input.GetKeyDown("s"))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            }
            if (Input.GetKeyDown("a"))
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
            if (Input.GetKeyDown("d"))
            {
                transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            }
        else
        {
            if (setTime)
            {
                inputWait = Time.time + inputDelay;
                setTime = false;
            }
            if (inputWait <= Time.time)
            {                
                canMove = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name + " COLLIDED");
        if (col.gameObject.tag == "enemy")
        {
            nextmicrogame.transition(false);
        }
        if (col.gameObject.tag == "win")
        {
            nextmicrogame.ProbabiltyMesser(difficulty.frogdifficulty);
            difficulty.frogdifficulty += 1;
            nextmicrogame.transition(true);
        }
    }
}
