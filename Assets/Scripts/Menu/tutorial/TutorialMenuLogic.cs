using TMPro;
using UnityEngine;

public class TutorialMenuLogic : MonoBehaviour
{
    public string[] MenuParagraphs;
    public GameObject[] MenuImages;
    [SerializeField] TMP_Text paragraph;
    static GameObject self;
    static bool showTutorial = true;
    string stringOutput;
    int page = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        self = gameObject;
        page = 0;
        if (!showTutorial)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        stringOutput = MenuParagraphs[page];
        if (stringOutput.Contains("//showSpace//"))
        {
            MenuImages[0].SetActive(true);
            stringOutput = stringOutput.Replace("//showSpace//", "");
        }
        else
        {
            MenuImages[0].SetActive(false);
        }
        if (stringOutput.Contains("//showWASD//"))
        {
            MenuImages[1].SetActive(true);
            stringOutput = stringOutput.Replace("//showWASD//", "");
        }
        else
        {
            MenuImages[1].SetActive(false);
        }
        if (stringOutput.Contains("//showMouse//"))
        {
            MenuImages[2].SetActive(true);
            stringOutput = stringOutput.Replace("//showMouse//", "");
        }
        else
        {
            MenuImages[2].SetActive(false);
        }

        paragraph.SetText(stringOutput);
        if (Input.GetKeyDown(KeyCode.D))
        {
            page++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            page--;
        }
        if (page >= MenuParagraphs.Length)
        {
            page = 0;
        }
        if (page < 0)
        {
            page = MenuParagraphs.Length - 1;
        }


    }

    public void ClosePressed()
    {
        self.SetActive(false);
        showTutorial = false;
    }
}
