using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        if (transform.position.y < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
