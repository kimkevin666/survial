
using System;
using UnityEngine;

public interface IDamagaIbe
{
    void TakePhysiaclDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagaIbe
{
    public UICondion uicondition;

    Condition health { get { return uicondition.health; } }
    Condition hunger { get { return uicondition.hunger; } }
    Condition stamina { get { return uicondition.stamina; } }


    public float noHungerHealthDecay;

    public event Action onTakeDamage;  //1-6강의 Action에 데미지에 대해 아무런 클래스가 없는 것이가?  Action을 선택하라고 했는데 선택을 안해서 오류가 남
    
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        hunger.Add(amount);
    }

    public void Eat(float amount) // Eat문 추가
    {
        hunger.Add(amount);
    }
    
    private void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }
    

    public void TakePhysiaclDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }
}
