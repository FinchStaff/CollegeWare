using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    AsyncOperation menuLoad;
    float timewait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuLoad = SceneManager.LoadSceneAsync(1);
        menuLoad.allowSceneActivation = false;
        timewait = Finch.TimeAdd(4);
        SettingHandler.displayKeys = true;
        Screen.SetResolution(1600, 900, false);
        SaveHandling.LoadSettings();
        SettingsMenu.SettingsApply();
    }
    void Update()
    {
        if (timewait <= Time.time)
        {
            menuLoad.allowSceneActivation = true;
        }
    }
}
