using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 25;
    [SerializeField] float timer = 5f;
    public void AddDamage(float addOn)
    {
        damage += addOn;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        if (collision.CompareTag("Building"))
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
