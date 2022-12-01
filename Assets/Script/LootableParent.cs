using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableParent : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedToPlayer = 1f;
    [SerializeField] float accelerateFactor = 10f;
    private void Start()
    {
        if (!rb)
        {
            rb = GetComponent<Rigidbody2D>();
            if (!rb) Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!this.gameObject.GetComponent<ChaseInRb>())
            {
                ChaseInRb thisNewScript = this.gameObject.AddComponent<ChaseInRb>();
                thisNewScript.rb = rb;
                thisNewScript.Target = collision.GetComponent<Transform>();
                thisNewScript.Speed = speedToPlayer;
                thisNewScript.accelerateFactor = accelerateFactor;
            }
            Destroy(this);
        }
    }
}
