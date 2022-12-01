using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] GameObject XpsPrefab;
    [SerializeField] int xp, coin;

    public new void TakeDamage(float damage)
    {
        hp -= damage;
        healthBar.value = hp / HEALTHPOINT;
        CheckDeath();
    }


    protected override void CheckDeath()
    {
        if (hp <= 0)
        {
            if (xp == 0) xp = 1;
            if (coin == 0) coin = 1;
            GameObject temp = GameObject.Instantiate(CoinPrefab, transform.position, Quaternion.identity);
            temp.GetComponentInChildren<Coins>().CoinsContained = coin;
            GameObject temp2 = GameObject.Instantiate(XpsPrefab, transform.position, Quaternion.identity);
            temp2.GetComponentInChildren<Xp>().XpContained = xp;
            Destroy(this.gameObject);
        }
    }
}
