using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour

{
    public float Hp;
    public float MaxHP = 10;
    private bool invicibility;


    public float CoinForHP = 10;
    public int RemoveCoins = 10;
    public CoinComponent Coincomponent;
    public float CoinHpAdd = 10;

    public delegate void OnHealthChangedHandler(float newHealth, float amountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHpInitializedHandler(float currentHealth);
    public event OnHpInitializedHandler OnHpInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = MaxHP;
        OnHpInitialized?.Invoke(Hp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {
        if (!invicibility)
        {
            Hp -= damage;
            OnHealthChanged?.Invoke(Hp, damage);
            invicibility = true;
            StartCoroutine(ResetInvicibility(3));
            //Debug.Log(Hp);

            if (Hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator ResetInvicibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invicibility = false;
        Debug.Log("reset");
    }
    public void AddHealing(float healing)
    {
        Hp += healing;
        OnHealthChanged?.Invoke(Hp, healing);
        //Debug.Log(Hp);
    }
    
}
