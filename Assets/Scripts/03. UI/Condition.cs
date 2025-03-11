using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;
    public float passiveValue;
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    public void Add(float Value)
    {
        curValue = Mathf.Min(curValue + Value, maxValue);
    }

    public void Subtract(float Value)
    {
        curValue = Mathf.Max(curValue - Value, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}
