using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingObj;
    public static bool fullscreen;
    public static int resolution;
    [SerializeField] Toggle[] toggles = new Toggle[2];
    [SerializeField] TMP_Dropdown[] dropdowns = new TMP_Dropdown[1];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggles[0].isOn = fullscreen;
        dropdowns[0].value = resolution;
    }
    
    void Update()
    {
        fullscreen = toggles[0].isOn;
        resolution  = dropdowns[0].value;
    }

    public static void SettingsApply()
    {
        if (resolution == 0)
        {
            Screen.SetResolution(1920, 1080, fullscreen);
        }
        else if (resolution == 1)
        {
            Screen.SetResolution(1600, 900, fullscreen);
        }
        else if (resolution == 2)
        {
            Screen.SetResolution(1280, 720, fullscreen);
        }
        SaveHandling.SaveSettings();
    }
}
