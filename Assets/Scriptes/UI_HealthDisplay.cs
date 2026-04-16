using System;
using TMPro;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI textComponent;
    void Start()
    {
        health.OnHealthChanged += OnHealthChanged;
        health.OnHpInitialized += OnHpInitialized;
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //throw new NotImplementedException();
        //Debug.Log(newHealth + ":" +  amountChanged);
        textComponent.text = newHealth.ToString();
    }
    private void OnHpInitialized(float currentHealth)
    {
        textComponent.text += currentHealth.ToString();
    }
}

