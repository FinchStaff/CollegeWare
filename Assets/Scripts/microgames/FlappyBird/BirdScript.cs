using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public static int flapdifficulty = 0;
    bool dead;
    float deadWait;
    public Rigidbody2D Rb2D;
    public float FlapStrength;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        flapdifficulty = Mathf.Clamp(flapdifficulty, 0,2);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                Rb2D.linearVelocity = Vector2.up * FlapStrength;
            }
        }
        else
        {
            if (Time.time >= deadWait)
                nextmicrogame.sceneload.allowSceneActivation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!dead){
            deadWait = Time.time + 1.5f;
            nextmicrogame.transition(false, true);
            countdown.countdownEnabled = false;
            dead = true;
        }

    }
}
