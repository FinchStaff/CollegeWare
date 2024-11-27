using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    bool win;
    bool lose;
    public void ChickenButton()
    {
        if(Movement.num == 0)
        {
            nextmicrogame.ProbabiltyMesser(RememberLogicScript.difficulty);
            RememberLogicScript.difficulty++;
            nextmicrogame.transition(true);
            Debug.Log("Chicken Win");
        }
        else
        {
            nextmicrogame.transition(false);
            Debug.Log("Chicken Lose");
        }
    }
    public void BeefButton()
    {
        if(Movement.num == 1)
        {
            nextmicrogame.ProbabiltyMesser(RememberLogicScript.difficulty);
            RememberLogicScript.difficulty++;
            nextmicrogame.transition(true);
            Debug.Log("Beef Win");
        }
        else
        {
            nextmicrogame.transition(false);
            Debug.Log("Beef Lose");
        }
    }
    public void CheeseOnionButton()
    {
        if(Movement.num == 2)
        {
            nextmicrogame.ProbabiltyMesser(RememberLogicScript.difficulty);
            RememberLogicScript.difficulty++;
            nextmicrogame.transition(true);
            Debug.Log("CheeseOnion Win");
        }
        else
        {
            nextmicrogame.transition(false);
            Debug.Log("CheeseOnion Lose");
        }
    }
}
