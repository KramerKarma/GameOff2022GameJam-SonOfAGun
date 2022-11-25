using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackColliderCheck : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float Timer = 0.2f;
    float timer;
    public float Damage{ get {return damage; } set { damage = value; } }
    // Start is called before the first frame update
    private void Start()
    {
        timer = Timer;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Timer;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Enemy"))
        {
            otherCollider.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
