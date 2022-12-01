using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    [SerializeField] float Timer = 2f; 
    float  timer;
    [SerializeField] MeeleAttackColliderCheck SwordSwingGFX;
    [SerializeField] Transform SwordSwingPosHolder;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        timer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            audioSource.Play();
            timer = Timer;
            SwordSwingGFX.gameObject.SetActive(true);
        }
    }
}
