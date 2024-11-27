using UnityEngine;

public class menuswitcher : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void SwitchToMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
