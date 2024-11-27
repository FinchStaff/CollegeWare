using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class carspawn : MonoBehaviour
{
    public List<GameObject> carPool;
    public int spawnAmount;
    public GameObject car;
    float wait;
    int chance = 50;
    int carRoll;


    //Creates object pool, makes computer not go boom boom :3
    public GameObject GetPooledObject()
        {

            for(int i = 0; i < spawnAmount; i++)
            {
                if(!carPool[i].activeInHierarchy)
                {
                    return carPool[i];
                }
            }
            return null;
        }


    // Start is called before the first frame update
    void Start()
    {
        countdown.count = 0;
        //Creates a pool of objects
        carPool = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < spawnAmount; i++)
        {
            tmp = Instantiate(car);
            tmp.SetActive(false);
            carPool.Add(tmp);
        }

        //Add a random amount of time
        wait = Time.time + Random.Range(0.10f, 0.60f);
    }

    void FixedUpdate()
    {
        //wait the inital amount of time, then roll the dice, then wait a random amount of time between 0.5 and 1.5
        if (wait <= Time.time)
        {
            carRoll = Random.Range(0, 100);
            if (carRoll <= chance) 
            {
                GameObject newcar = GetPooledObject();
                if (newcar != null)
                {
                    newcar.transform.position = transform.position;
                    newcar.transform.rotation = transform.rotation;
                    newcar.SetActive(true);
                }
            }
            wait = Time.time + Random.Range(0.50f, 1.50f);
        }
    }
}
