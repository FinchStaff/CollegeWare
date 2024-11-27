using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class resultsfadeout : MonoBehaviour
{
    public static bool fading;
    public GameObject blackScreen;
    [SerializeField] TMP_Text resultsAreIn;
    RawImage imageBlack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fading = true;
        imageBlack = blackScreen.GetComponent<RawImage>();
        StartCoroutine(FadeOutCorutine());
    }

    IEnumerator FadeOutCorutine()
    {
        float fadeOutRate = 0.025f;
        while (resultsAreIn.alpha > 0)
        {
            resultsAreIn.alpha -= fadeOutRate;
            imageBlack.color = new Color(imageBlack.color.r, imageBlack.color.g, imageBlack.color.b, imageBlack.color.a - fadeOutRate);
            yield return new WaitForSeconds(0.05f);
        }
        fading = false;
    }
}
