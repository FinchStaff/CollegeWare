using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class WindowSettings : MonoBehaviour
{

    public void ChangeResolution()
    {
        string text = gameObject.GetComponent<TMP_Text>().text;
        int splitIndex = text.LastIndexOf("x");
        Debug.Log(text.Substring(0, splitIndex) + " " + text.Substring(splitIndex+1));
        int width = int.Parse(text.Substring(0, splitIndex));
        int height = int.Parse(text.Substring(splitIndex+1));
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
