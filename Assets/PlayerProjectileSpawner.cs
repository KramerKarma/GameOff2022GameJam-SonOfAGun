using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectileSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> enemyTransform = new List<Transform>();
    [SerializeField] float Timer= 1f , speed = 1f;
    float timer;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPos;
    [SerializeField] Slider ActionBar;
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
        if (enemyTransform.Count > 0)
        {
            List<int> IndexToDelete = new List<int>();
            for(int i =0;i<enemyTransform.Count;i++)
            {
                if (enemyTransform[i] == null)
                {
                    IndexToDelete.Add(i);
                }
            }
            for(int i =0;i< IndexToDelete.Count; i++)
            {
                enemyTransform.RemoveAt(IndexToDelete[IndexToDelete.Count - 1 - i]);
            }
            GameObject tempGBholder = GameObject.Instantiate(projectile, spawnPos.position, Quaternion.identity);
            tempGBholder.GetComponent<Rigidbody2D>().velocity = (FindClosest(transform.position) - spawnPos.position).normalized * speed;

        }
        
    }
     
    public void AddEnemy(Transform enemyTran)
    {
        enemyTransform.Add(enemyTran);
    }
    Vector3 FindClosest(Vector3 postion)
    {
        Vector3 nearestEnemy = new Vector3(1f, 0f, 0f);
        float minimumDistance = Mathf.Infinity;
        foreach (Transform tran in enemyTransform)
        {
            float distance = Vector3.Distance(tran.position, postion);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = tran.position;
            }
        }
        return nearestEnemy;
    }
}
