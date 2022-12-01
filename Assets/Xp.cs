using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp : Lootable
{
    [SerializeField] int xpContained;
    
    public int XpContained { get { return xpContained; } set { xpContained = value; } }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.TheGM.PlayerStatManager.AddXps(xpContained);
            Destroy(this.parentToDestroy.gameObject);
        }
    }
}
