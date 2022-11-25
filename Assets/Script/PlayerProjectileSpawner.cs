using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] float Timer= 1f , speed = 1f;
    float timer;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPos;
    [SerializeField] Slider ActionBar;
    [SerializeField] TargetManager targetManager;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.3f;
        ActionBar.value = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        ActionBar.value = 1 - timer / Timer;
        if (timer<=0)
        {
            ShootEnemy();
            timer = Timer;
        }
    }

    void ShootEnemy()
    {
        if (targetManager.EnemyTransform.Count > 0)
        {
            targetManager.CheckAndRemoveTheNullObject();
            GameObject tempGBholder = GameObject.Instantiate(projectile, spawnPos.position, spawnPos.GetComponentInParent<Transform>().rotation);
            Vector2 direction = (targetManager.FindClosest(transform.position) - spawnPos.position).normalized;
            tempGBholder.GetComponent<Rigidbody2D>().velocity = direction * speed;

        }
        
    }
    
}
