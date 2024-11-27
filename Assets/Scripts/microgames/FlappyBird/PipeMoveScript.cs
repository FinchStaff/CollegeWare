using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
    public float DeadZone = -45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position /* The position of the object this code is for */ += (Vector3.left * MoveSpeed) /* Vector3.left is (-1,0,0) */ * Time.deltaTime /* Time.deltaTime fixes inconsistent frame rate issues */;
        
        // Checks if pipes have gone past the dead zone and destroys them if they have so that we save memory
        if (transform.position.x < DeadZone)
        {
            Debug.Log("Pipe Deleted");
            gameObject.SetActive(false);
        }
    }
}
