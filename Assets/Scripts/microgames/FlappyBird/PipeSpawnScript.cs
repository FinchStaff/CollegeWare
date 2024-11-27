using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public List<GameObject> pipePool;
    public GameObject pipe;
    public int spawnAmount;
    public float SpawnRate = 2;
    private float timer = 0;
    public float HeightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        // makes pool of objects
        pipePool = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < spawnAmount; i++)
        {
            tmp = Instantiate(pipe);
            tmp.SetActive(false);
            pipePool.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            GameObject newPipe = GetPooledObject();
            if (newPipe != pipe)
            {
                float lowestPoint = transform.position.y - HeightOffset;
                float highestPoint = transform.position.y + HeightOffset;
                newPipe.transform.position = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
                newPipe.transform.rotation = transform.rotation;
                newPipe.SetActive(true);
            }
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - HeightOffset;
        float highestPoint = transform.position.y + HeightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < spawnAmount; i++)
        {
            if (!pipePool[i].activeInHierarchy)
            {
                return pipePool[i];
            }
        }
        return null;
    }
}
