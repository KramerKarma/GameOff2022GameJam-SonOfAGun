using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform playerTran;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 15f;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerTran) 
        {
            if (GameObject.Find("Player"))
            {
                playerTran = GameObject.Find("Player").GetComponent<Transform>();
            }
            else
            {
                Destroy(this);
            }
        }
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTran) { rb.velocity = new Vector2(0f, 0f); Destroy(this);}
    }
    private void FixedUpdate()
    {
        if (playerTran)
        {
            direction = new Vector2(playerTran.position.x - transform.position.x, playerTran.position.y - transform.position.y).normalized;
        }
        if (direction.x > 0) spriteRenderer.flipX = true; else spriteRenderer.flipX = false;
        rb.velocity = direction * speed;
    }
}
