using JetBrains.Annotations;
using UnityEngine;

public class Health : MonoBehaviour

{
    private float Hp = 5;
    public float MaxHP = 10;

// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        Hp -= damage;
        Debug.Log(Hp);

        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
  public void AddHealing(float healing)
    {
        Hp += healing;
        Debug.Log(Hp);
    }

}
