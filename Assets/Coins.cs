using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Lootable
{
    [SerializeField] int coinsContained;
    public int CoinsContained { get{ return coinsContained; }set { coinsContained = value; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.TheGM.PlayerStatManager.AddCoins(coinsContained);
            Destroy(this.parentToDestroy.gameObject);
        }
    }
}
