using TMPro;
using UnityEngine;

public class bg : MonoBehaviour
{
    
    //Literally all this does is set the background of the menu to a random colour

    [SerializeField] TMP_Text versionNum;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = Random.ColorHSV();
        string version = Application.version;
        versionNum.SetText("Version: " + version);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.backgroundColor = color;
    }
}
