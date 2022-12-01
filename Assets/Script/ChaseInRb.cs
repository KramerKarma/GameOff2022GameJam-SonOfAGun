using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseInRb : MonoBehaviour
{   public Transform Target { get; set;}
    public Rigidbody2D rb { get; set;}
    [SerializeField] public float Speed { get; set; }
    [SerializeField] public float accelerateFactor { get; set; }
    Vector2 dir;
    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            dir = new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y);
            dir = dir.normalized;
        }
        
    }
    private void FixedUpdate()
    {
        Speed += Time.fixedDeltaTime* accelerateFactor;
        rb.velocity = dir*Speed;
        //if (Vector2.Angle(rb.velocity,dir)>) { }
    }
}
