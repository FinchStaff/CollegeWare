using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    GameObject[] enemyPool;
    public static int difficulty;
    bool notRun = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        difficulty = Mathf.Clamp(difficulty, 0,2);
        enemyPool = Finch.CreatePool(3, enemyObject);
        StartCoroutine(EnemySpawn(4 - difficulty));
    }

    IEnumerator EnemySpawn(int timeInterval)
    {
        int left = 1;
        GameObject enemySpawning;
        while (true)
        {
            int randomNum = Random.Range(0,2);
            if (randomNum == 0)
                left = -1;
            else
                left = 1;
            enemySpawning = Finch.PoolGetInactive(enemyPool);
            if (enemySpawning != null){
                enemySpawning.transform.position = new Vector2(0.5f*left, transform.position.y);
                enemySpawning.SetActive(true);
            }
            yield return new WaitForSeconds(timeInterval);
        }
    }

    void Update()
    {
        if (SceneManager.sceneCount == 2 && notRun && ProbabilityHandler.difficultyChange)
        {
            nextmicrogame.ProbabiltyMesser(difficulty);
            difficulty++;
            nextmicrogame.sceneload.allowSceneActivation = true;
            notRun = false;
        }

    }
}
