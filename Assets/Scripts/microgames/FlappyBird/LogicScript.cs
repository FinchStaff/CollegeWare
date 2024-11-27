using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    bool running = false;
    void Awake()
    {
        countdown.count = 3 * BirdScript.flapdifficulty;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("flapdiff = "+BirdScript.flapdifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.sceneCount == 2)
        {
            if (ProbabilityHandler.difficultyChange)
            {
                if (!running)
                {
                    nextmicrogame.ProbabiltyMesser(BirdScript.flapdifficulty);
                    BirdScript.flapdifficulty++;
                }
                running = true;
                nextmicrogame.sceneload.allowSceneActivation = true;
            }
        }
    }
}
