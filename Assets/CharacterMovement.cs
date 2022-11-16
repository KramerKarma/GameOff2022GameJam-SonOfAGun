using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector2 direction;
    Vector2 faceDire;
    [SerializeField] float speed = 15f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TargetManager targetManager;
    Vector3 mousePostion;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!targetManager) targetManager = GetComponent<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePostion.x - transform.position.x, mousePostion.y - transform.position.y).normalized;
        if (Mathf.Abs(mousePostion.x - transform.position.x)+Mathf.Abs(mousePostion.y - transform.position.y) < 1f)
        {
                direction.x = 0f;
                direction.y = 0f;
        }
        
    }
    private void FixedUpdate()
    {
        //Debug.Log(mousePostion.x - transform.position.x);
        rb.velocity = direction * speed;
        Vector3 attackingPos = targetManager.FindClosest(transform.position);
        faceDire = new Vector2(attackingPos.x - transform.position.x, attackingPos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(faceDire.y, faceDire.x) * Mathf.Rad2Deg;
        targetManager.RotateTheGFX(angle);
    }
}
