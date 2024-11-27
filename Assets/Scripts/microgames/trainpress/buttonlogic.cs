using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonlogic : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public static int difficulty = 0;
    int spaceForgive, spaceSin;
    bool stretchHand;
    float leniancy, timeWait, timeout, changeScene, stretchTime;
    SpriteRenderer sprite;
    [SerializeField] Sprite[] sprites = new Sprite[2];
    bool waiting, running;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        running = false;
        waiting = true;
        spaceSin = 0;
        difficulty = Mathf.Clamp(difficulty, 0, 2);
        switch (difficulty)
        {
            case 0:
                leniancy = 1.5f;
                spaceForgive = 3;
                break;
            case 1:
                leniancy = 1f;
                spaceForgive = 2;
                break;
            case 2:
                leniancy = 0.5f;
                spaceForgive = 1;
                break;
        }
        timeWait = Time.time + Random.Range(2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            Debug.Log("Wait: " + timeWait + " Time: " + Time.time);
            if (Time.time >= timeWait)
            {
                gameObject.GetComponent<AudioSource>().enabled = true;
                text.SetText("PRESS SPACE!");
                timeout = Time.time + leniancy;
                sprite.sprite = sprites[1];
                waiting = false;
            }
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                spaceSin++;
                stretchTime = Finch.TimeAdd(0.5f);
                timeWait += 0.5f;
                if (spaceSin >= spaceForgive)
                    nextmicrogame.transition(false);
                stretchHand = true;
            }
            if (stretchHand && stretchTime > Time.time)
            {
                text.SetText("TOO EARLY!");
                hand.pressing = true;
            }
            else if (stretchHand && stretchTime <= Time.time)
            {
                text.SetText("Wait for it!");
                hand.pressing = false;
                stretchHand = false;
            }
        }
        else
        {
            if (!running){
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    nextmicrogame.ProbabiltyMesser(difficulty);
                    difficulty++;
                    hand.pressing = true;
                    changeScene = Time.time + 1.5f;
                
                    nextmicrogame.transition(true, true);
                    running = true;
                }
                else if (Time.time >= timeout)
                {
                    changeScene = Time.time;
                    nextmicrogame.transition(false, true);
                    running = true;
                    nextmicrogame.sceneload.allowSceneActivation = true;
                }
            }
        }
        if (SceneManager.sceneCount == 2)
        {
            if (Time.time >= changeScene)
            {
                nextmicrogame.sceneload.allowSceneActivation = true;
            }
        }

    }
}
