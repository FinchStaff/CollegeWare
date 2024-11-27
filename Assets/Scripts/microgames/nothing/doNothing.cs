using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doNothing : MonoBehaviour
{
    Vector2 originalmousepos;
    float mercyTime;
    bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        mercyTime = Time.time + 0.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (mercyTime < Time.time)
        {
            if ((originalmousepos.x != Input.mousePosition.x && originalmousepos.y != Input.mousePosition.y || Input.anyKey) && !running)
            {
                nextmicrogame.transition(false);
                running = true;
            }
        }
        else
            originalmousepos = Input.mousePosition;
        
        if (SceneManager.sceneCount == 2 && !running)
        {
            nextmicrogame.sceneload.allowSceneActivation = true;
            running = true;
        }
    }
}
