using UnityEngine;

public class Healing : MonoBehaviour
{
    public float HealingValue = 1;
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
        collision.GetComponent<Health>().AddHealing(HealingValue);
        Destroy(gameObject);
    }



}
