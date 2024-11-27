using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] TMP_Text wintext;
    [SerializeField] GameObject button;
    float originalsize;
    bool fontgrow = true, fontrotate = true;
    // Start is called before the first frame update
    void Start()
    {
        wintext.alpha = 0;
        originalsize = wintext.fontSize;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!resultsfadeout.fading){
            button.SetActive(true);
            if (wintext.alpha < 1)
            {
                wintext.alpha += 0.01f;
            }

            if (fontgrow)
            {
                wintext.fontSize += 0.1f;
                if (wintext.fontSize >= (originalsize + 10))
                {
                    fontgrow = false;
                }
            }
            else
                {
                    wintext.fontSize -= 0.1f;
                    if (wintext.fontSize <= originalsize)
                    {
                        fontgrow = true;
                    }
                }
            
            if (fontrotate)
            {
                wintext.rectTransform.rotation = new Quaternion(0, 0, wintext.rectTransform.rotation.z + 0.0005f, wintext.rectTransform.rotation.w);
                Debug.Log(wintext.rectTransform.rotation);
                if (wintext.rectTransform.rotation.z >= 0.033333333)
                {
                    fontrotate = false;
                }
            }
            else
            {
                wintext.rectTransform.rotation = new Quaternion(0, 0, wintext.rectTransform.rotation.z - 0.0005f, wintext.rectTransform.rotation.w);
                if (wintext.rectTransform.rotation.z <= -0.03333333)
                {
                    fontrotate = true;
                }
            }
        }
    }
}
