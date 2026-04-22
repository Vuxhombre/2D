using UnityEngine;

public class CoinComponent : MonoBehaviour
    
{
    public int CoinAmount;
    
    public delegate void OnCoinChangedHandler(int newCoin, int amountChanged);
    public event OnCoinChangedHandler OnCoinChanged;


    public delegate void OnCoinInitializerHandler(int currentCoinAmount);
    public event OnCoinInitializerHandler OnCoinInitialized;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      CoinAmount = 0;
      OnCoinInitialized?.Invoke(CoinAmount);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoin(int coinValue)
    {
        CoinAmount += coinValue;
        OnCoinChanged?.Invoke(CoinAmount, coinValue);
    }
}
