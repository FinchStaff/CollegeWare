using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class secretkeep : MonoBehaviour
{
    TMP_Text text;
    [SerializeField] TMP_Text pressSpace;
    [SerializeField] GameObject countDown;
    string secretText, writtenText = "";
    int i;
    float timeWait;
    bool writing, timeDone, fadingIn, done, spacePressed, load;
    char[] chars;
    string[] secrets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secrets = new string[] { "We are Better Than You", "This game is literally just WarioWare", "These secrets were made in like 5 minutes", "WARRIIO!", "That's cool" };
        //Holy yapperoni
        i = 0;
        writing = true;
        done = false;
        load = true;
        fadingIn = true;
        timeDone = true;
        spacePressed = false;
        text = gameObject.GetComponent<TMP_Text>();
        secretText = text.text;
        chars = secretText.ToCharArray();
        text.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (writing)
        {
            if (timeDone)
            {
                writtenText += chars[i];
                i++;
                timeWait = Finch.TimeAdd(0.2f);
                text.SetText(writtenText);
                timeDone = false;
            }
            else
            {
                if (timeWait <= Time.time)
                {
                    timeDone = true;
                }
            }
            if (i+1 > chars.Length)
            {
                writing = false;
            }
        }
        else
        {
            if (fadingIn)
            {
                pressSpace.alpha += 0.1f;
                Debug.Log(pressSpace.alpha);
                timeWait = Finch.TimeAdd(0.1f);
                fadingIn = false;
            }
            else
            {
                if (timeWait <= Time.time)
                {
                    fadingIn = true;
                }
            }
            if (pressSpace.alpha >= 1)
            {
                done = true;
            }
        }
        if (done)
        {
            countDown.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                countdown.countdownEnabled = false;
                spacePressed = true;
                done = false;
            }
        }
        if (spacePressed)
        {
            if (load)
            {
                timeWait = Finch.TimeAdd(2);
                text.SetText(secrets[UnityEngine.Random.Range(0,secrets.Length)]);
                load = false;
            }
            else if (timeWait <= Time.time)
            {
                nextmicrogame.transition(true);
            }
        }
    }
}
