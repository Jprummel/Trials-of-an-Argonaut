using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _healthBar;
    private float _fillAmount;

    public void HandleBar(float currentHealth, float maxHealth)
    {
        _fillAmount = Map(currentHealth, 0, maxHealth, 0, 1);
        _healthBar.fillAmount = _fillAmount;
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
