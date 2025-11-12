
using UnityEngine;
using UnityEngine.UI;
public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image uibar;
  
    void Start()
    {
        curValue = startValue;
    }

 
    void Update()
    {
        // ui업데이트
        uibar.fillAmount = GetPercentage();
    }
    //계산 함수
    float GetPercentage()
    {
       // Debug.Log(curValue + "");
       // Debug.Log(maxValue + "");
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value,maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue-value,0);
    }
    
}
