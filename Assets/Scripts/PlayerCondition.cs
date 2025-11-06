
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondion uicondition;

    Condition Health { get { return uicondition.health; } }
    Condition Hunger { get { return uicondition.hunger; } }
    Condition Stamina { get { return uicondition.stamina; } }

    // Start is called before the first frame update

    public float noHungerHealthDecay;

    // Update is called once per frame
    void Update()
    {
        Hunger.Subtract(Hunger.passiveValue * Time.deltaTime);
        Stamina.Add(Stamina.passiveValue * Time.deltaTime);

        if (Hunger.curValue == 0f)
        {
            Health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (Health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        Hunger.Add(amout);
    }

    public void Die()
    {
        Debug.Log("죽었다.");
    }
}
