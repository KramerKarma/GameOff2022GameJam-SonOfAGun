using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] float TIMER = 1f;
    [SerializeField] float timer;
    Collider2D collider2D;
    public float Timer { get{ return TIMER; }set { TIMER = value; } }
    // Start is called before the first frame update
    void Start()
    {
        if (!playerHealth) { Debug.LogError("playerHealth in PlayerDamageReceiver was not assigned"); }
        collider2D = this.GetComponent<Collider2D>();
        if (!collider2D) Destroy(this);
    }
    private void FixedUpdate()
    {
        if (timer>0) {
            timer -= Time.fixedDeltaTime;
        }
        if (timer<=0&&!collider2D.enabled)
        {
            timer = TIMER;
            collider2D.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        if (otherCollider2D.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(otherCollider2D.GetComponent<EnemyDamage>().DamageToDealt);
            collider2D.enabled = false;
        }
    }
}
