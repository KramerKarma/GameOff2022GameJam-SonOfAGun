using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthPoint = 100;
    public void TakeDamage(int damage)
    {
        healthPoint -= damage;
        if (healthPoint<=0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Heal(int heal)
    {
        healthPoint += heal;
    }
}
