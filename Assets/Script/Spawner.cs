using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float TIMER = 3f;
    float time = 0f;
    [SerializeField] float Counter = 999;
    [SerializeField] TargetManager playerInfo;
    private void Start()
    {
        if (!playerInfo) playerInfo = GameObject.Find("Player").GetComponent<TargetManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (time<=0)
        {
            GameObject tempGB = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
            playerInfo.AddEnemy(tempGB.transform);
            time = TIMER;
            Counter -= 1;
            float tempCounter = 970;
            while(Counter<tempCounter)
            { 
                tempGB.GetComponent<Health>().Healthpoint = 10;
                tempCounter -= 30;
            }
        }
        time -= Time.deltaTime;

        if (Counter<0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
