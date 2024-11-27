using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerHitDetect : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            nextmicrogame.transition(false);
        }
    }
}
