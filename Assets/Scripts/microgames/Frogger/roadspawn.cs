
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class roadspawn : MonoBehaviour
{
    public GameObject roadright;
    public GameObject roadleft;
    public GameObject road;

    Vector2 screenBounds;
    [SerializeField] Camera cam;

    //Available roadspawn coords
    public List<float> roadspawncoord = new List<float>{};
    
    // Start is called before the first frame update
    void Start()
    {
        roadspawncoord = new List<float>();
        Debug.Log("ScreenBounds roadspawn: " + difficulty.screenBounds);
        for(float i = (difficulty.screenBounds.y * -1) + 1.5f; i < difficulty.screenBounds.y + 0.5; i += 1)
        {
            roadspawncoord.Add(i);
        }

        Debug.Log(difficulty.screenBounds * -1 + "SCREENBOUND");

        //The max number of roads that can spawn
        int maxroads = roadspawncoord.Count - 3;
        //Generate a random number of roads to spawn
        float roads = Random.Range(maxroads - Mathf.Floor(maxroads/4), maxroads);
        Debug.Log("Maxroads: " + maxroads);

        //For loop to generate each road
        for(int i = 0; i <= roads; i++)
        {
            //Generate a random number between 0 and 99
            int rannum = Random.Range(0,100);
            //if rannum is less than or equal to 50 then create a road going to the left
            if (rannum <= 50)
            {
                //generate random road pos from list
                int randomRoadPos = Random.Range(0, roadspawncoord.Count-1);

                //Create a new road object
                Instantiate(roadleft, new Vector3(difficulty.screenBounds.x * - 1, roadspawncoord[randomRoadPos]), Quaternion.identity);
                Instantiate(road, new Vector3(0, roadspawncoord[randomRoadPos]), Quaternion.identity);
                //Remove the coordinate from the array
                roadspawncoord.Remove(roadspawncoord[randomRoadPos]);
            }

            //Does the same as above, but instead facing right instead, reflected
            else if (rannum > 50)
            {
                int randomRoadPos = Random.Range(0, roadspawncoord.Count-1);
                Instantiate(roadright, new Vector2(difficulty.screenBounds.x, roadspawncoord[randomRoadPos]), Quaternion.identity);
                Instantiate(road, new Vector2(0, roadspawncoord[randomRoadPos]), Quaternion.identity);
                roadspawncoord.Remove(roadspawncoord[randomRoadPos]);
            }
        }
    }
}
