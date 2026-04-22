using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CoinComponent>().AddCoin(coinValue);
        Destroy(this.gameObject);
    }
}
