using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    float count;
    bool timeGet;
    // Start is called before the first frame update
    void Start()
    {
        timeGet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!resultsfadeout.fading){
            if (timeGet){count = Finch.TimeAdd(5); timeGet = false;}
            if(Time.time >= count)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
