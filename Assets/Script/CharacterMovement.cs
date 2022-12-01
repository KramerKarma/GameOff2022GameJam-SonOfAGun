using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector2 direction;
    Vector2 faceDire;
    [SerializeField] float speed = 15f;
    float slowSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TargetManager targetManager;
    [SerializeField] Transform GFXtran;
    Vector3 mousePostion;
    float addiSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!targetManager) targetManager = GetComponent<TargetManager>();
        slowSpeed = speed * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get mouse postion with camera.screentoWorldPoint.
        direction = new Vector2(mousePostion.x - transform.position.x, mousePostion.y - transform.position.y).normalized;//get direction  
    }
    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
        if (Mathf.Abs(mousePostion.x - transform.position.x) + Mathf.Abs(mousePostion.y - transform.position.y) < 2f)
        {
            rb.velocity = direction * slowSpeed;
        }
        if (Mathf.Abs(mousePostion.x - transform.position.x) + Mathf.Abs(mousePostion.y - transform.position.y) < 1f)
        {
            direction.x = 0f;
            direction.y = 0f;
            rb.velocity = direction;
        }
        //Debug.Log(mousePostion.x - transform.position.x);
        
        //change sprite direction with localScale
        if (direction.x > 0) { if (GFXtran.localScale.x > 0) { GFXtran.localScale = new Vector3(-1 * GFXtran.localScale.x, GFXtran.localScale.y, GFXtran.localScale.z); } } else if (GFXtran.localScale.x < 0) GFXtran.localScale = new Vector3(-1 * GFXtran.localScale.x, GFXtran.localScale.y, GFXtran.localScale.z);

        Vector3 attackingPos = targetManager.FindClosest(transform.position);
        faceDire = new Vector2(attackingPos.x - transform.position.x, attackingPos.y - transform.position.y).normalized;
        float angle = Mathf.Atan2(faceDire.y, faceDire.x) * Mathf.Rad2Deg;
        targetManager.RotateTheGFX(angle);
    }
    public float AddiSpeed { get {return addiSpeed; } set{ addiSpeed = value; speed += addiSpeed * 0.001f; } }
}
