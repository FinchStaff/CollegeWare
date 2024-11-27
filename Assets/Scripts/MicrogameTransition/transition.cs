using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneChances
{
    public static int 
        nothingChance = 2,
        secretChance  = 3;
        
    public static int
        previousMicrogame = -1;
}
public class transition : MonoBehaviour
{
    float count;
    bool WinLose = false;
    bool notrun = true;
    AsyncOperation loadScene;
    int random, secondRandom; 
    public GameObject hearts;
    Coroutine slowPrint;
    public TMP_Text text;
    [SerializeField] GameObject MGtrans, WinLoseTrans;
    [SerializeField] TMP_Text resultsAreIn;
    [SerializeField] GameObject[] keys; // 0 space, 1 WASD, 2 Mouse, 3 None
    
    public TMP_Text MGCount;
    private float heartwidth = 181;
    static (string, int) getText(int random)
    {
        string sceneName = SceneManager.GetSceneByBuildIndex(random).name;
        switch (sceneName.ToLower())
        {
            case "frogger":
                return ("Cross the road to college!", 1);
            case "maths":
                return ("Calculate", 2);
            case "typing":
                return ("Type!", 3);
            case "flappybird":
                return ("Don't get caught", 0);
            case "trainpress":
                return ("Press the button in time!", 0);
            case "canyoukeepasecret":
                return ("I have something to ask you", 0);
            case "remember":
                return ("Remember your order!", 2);
            case "corridorrun":
                return ("Be careful in the corridor!", 0);
            default:
                return ("Whoops, something went wrong!", 3);
        }
    }
    void Awake()
    {
        start.PrintIDArray();
        countdown.count = 0;
        WinLose = false;
        if (nextmicrogame.health <= 0)
        {
            loadScene = SceneManager.LoadSceneAsync(3);
            loadScene.allowSceneActivation = false;
            WinLose = true;
        }
        else if (nextmicrogame.MGdone == 16)
        {
            loadScene = SceneManager.LoadSceneAsync(4);
            loadScene.allowSceneActivation = false;
            WinLose = true;
        }
        if (WinLose)
        {
            MGtrans.SetActive(false);
            WinLoseTrans.SetActive(true);
        }
    }
    void Start()
    {
        if (!WinLose){
            Debug.Log("flapdiff = "+BirdScript.flapdifficulty);
            if (nextmicrogame.MGdone != 16 && nextmicrogame.health > 0)
            {
                while (true){
                    random = nextmicrogame.loadnext();
                    if (random == 8 && SceneChances.previousMicrogame != random)
                    {
                        Debug.Log("Rolled a nothing!");
                        secondRandom = UnityEngine.Random.Range(0, SceneChances.nothingChance);
                        if (secondRandom == 0)
                        {
                            loadScene = SceneManager.LoadSceneAsync(random);
                            break;
                        }
                    }
                    else if (random == 9 && SceneChances.previousMicrogame != random)
                    {
                        Debug.Log("Rolled a secret!");
                        secondRandom = UnityEngine.Random.Range(0, SceneChances.secretChance);
                        if (secondRandom == 0)
                        {
                            loadScene = SceneManager.LoadSceneAsync(random);
                            break;
                        }
                    }
                    else if (SceneChances.previousMicrogame == random)
                    {
                        Debug.Log("Not running multiple of microgame");
                    }
                    else
                    {
                        loadScene = SceneManager.LoadSceneAsync(random);
                        break;
                    }
                }
                Debug.Log("Random: "+random+"\nSecond Random: "+secondRandom);
                loadScene.allowSceneActivation = false;
                SceneChances.previousMicrogame = random;
                //Handles the life system
                RectTransform heartsize = hearts.GetComponent<RectTransform>();
                heartsize.sizeDelta = new Vector2(heartwidth * nextmicrogame.health, heartsize.sizeDelta.y);
                count = Time.time + 2;
                MGCount.SetText(Convert.ToString(nextmicrogame.MGdone)+"/15");
        }
    
    
        }
        else
        {
            slowPrint = StartCoroutine(Finch.SlowWrite(resultsAreIn, 0.5f, "The results are in...", true));
            Debug.Log("This has run");
        }
    }

    void Update()
    {
        if (!WinLose){
            if (nextmicrogame.health > 0){
                if (loadScene.progress >= 0.9f){
                    if(Time.time >= count && notrun){displaytext();}
                }
                if(Time.time >= count && !notrun){loadScene.allowSceneActivation = true;}
            }
        }
        if (Finch.slowPrintFin)
        {
            loadScene.allowSceneActivation=true;
            Finch.slowPrintFin = false;
        }
    }

    void displaytext()
    {
        if (SceneManager.GetSceneByBuildIndex(random).name != "nothing"){
            Debug.Log(SceneManager.GetSceneByBuildIndex(random).name);
            count += 2;
            hearts.SetActive(false);
            (string TextOutput, int key) = getText(random);
            text.SetText(TextOutput);
            if (key != 3)
            {
                keys[key].SetActive(true);
            }
            text.gameObject.SetActive(true);
            notrun = false;
        }
        else
        {
            loadScene.allowSceneActivation = true;
        }
    }

}
