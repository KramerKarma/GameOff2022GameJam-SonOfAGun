using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] HealthBarManager healthBarManager;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("Taking 15 damage");
    //        TakeDamage(15f);
    //    }
    //}
    public new void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (hp/HEALTHPOINT<0.75f)
        {
            healthBarManager.SwitchSprite(1);
        }
        if (hp / HEALTHPOINT < 0.50f)
        {
            healthBarManager.SwitchSprite(2);
        }
        if (hp / HEALTHPOINT < 0.25f)
        {
            healthBarManager.SwitchSprite(3);
        }
        if (hp / HEALTHPOINT <= 0)
        {
            healthBarManager.SwitchSprite(4);
        }
    }
    public new void Heal(float heal)
    {
        base.Heal(heal);
        if (hp / HEALTHPOINT > 0.75f)
        {
            healthBarManager.SwitchSprite(0);
        }
        if (hp / HEALTHPOINT > 0.50f)
        {
            healthBarManager.SwitchSprite(1);
        }
        if (hp / HEALTHPOINT > 0.25f)
        {
            healthBarManager.SwitchSprite(2);
        }
        if (hp / HEALTHPOINT > 0)
        {
            healthBarManager.SwitchSprite(3);
        }
    }
}
