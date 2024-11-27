using UnityEngine;

public class DisplayKeys : MonoBehaviour
{
    void Start()
    {
        if (!SettingHandler.displayKeys)
            gameObject.SetActive(false);
    }
}
