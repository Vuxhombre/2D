using System.ComponentModel;
using TMPro;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI textcomponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health.OnHealthChanged += OnHealthChanged;
        health.OnHpInitialized += OnHpInitialized;
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log(newCoin + ":" + amountChanged);
        textcomponent.text = newHealth.ToString();
    }
    private void OnHpInitialized(float currentHealth)
    {
        textcomponent.text += currentHealth.ToString();
    }
    
}

