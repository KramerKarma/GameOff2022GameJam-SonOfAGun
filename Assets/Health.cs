using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float HEALTHPOINT = 100;
    float hp = 100;
    [SerializeField] Slider healthBar;
    private void Awake()
    {
        hp = HEALTHPOINT;
        healthBar.value = 1;
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar.value = hp / HEALTHPOINT;
        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }
    public void Heal(int heal)
    {
        hp += heal;
        if (hp> HEALTHPOINT)
        {
            hp = HEALTHPOINT;
        }
    }
}
