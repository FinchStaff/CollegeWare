using UnityEngine;

public class HerobrineHandler : MonoBehaviour
{
    public GameObject Herobrine;
    void Start()
    {
       int appear = Random.Range(0,500);
       if (appear == 0)
       {
            Herobrine.SetActive(true);
       }
       Debug.Log("Herobrine roll: "+appear);
    }
}
