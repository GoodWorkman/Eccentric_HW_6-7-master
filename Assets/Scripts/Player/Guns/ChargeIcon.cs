using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _foreground;

    [SerializeField] private TextMeshProUGUI _chargeText;

    public void StartCharge()
    {
        _background.color = new Color(1f, 1f, 1f, 0.2f);
        _foreground.enabled = true;
        _chargeText.enabled = true;
    }
    
    public void StopCharge()
    {
        _background.color = new Color(1f, 1f, 1f, 1f);
        _foreground.enabled = false;
        _chargeText.enabled = false;
    }

    public void SetChargeValue(float currentValue, float maxValue)
    {
        _foreground.fillAmount = currentValue / maxValue;

        _chargeText.text = Mathf.Ceil(maxValue - currentValue).ToString();
    }
}
