using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform playerTran;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 15f;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (!playerTran) playerTran = GameObject.Find("Player").GetComponent<Transform>();
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (playerTran.position - transform.position).normalized;
    }
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
