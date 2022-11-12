using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector2 direction;
    [SerializeField] float speed = 15f;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.y = Input.GetAxis("Vertical");
        direction.x = Input.GetAxis("Horizontal");      
    }
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
