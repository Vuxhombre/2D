using System.ComponentModel;
using TMPro;
using UnityEngine;

public class UI_CoinDisplay : MonoBehaviour
{
    public CoinComponent CoinComponent;
    public TextMeshProUGUI textcomponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CoinComponent.OnCoinChanged += OnCoinChanged;
        CoinComponent.OnCoinInitialized += OnCoinInitialized;
    }

    private void OnCoinChanged(int newCoin, int amountChanged)
    {
        //Debug.Log(newCoin + ":" + amountChanged);
        textcomponent.text = newCoin.ToString();
    }
    private void OnCoinInitialized(int currentCoinAmount)
    {
        textcomponent.text += currentCoinAmount.ToString();
    }
}
