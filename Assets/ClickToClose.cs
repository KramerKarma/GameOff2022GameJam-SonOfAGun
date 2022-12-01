using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToClose : MonoBehaviour
{
    [SerializeField] AudioSource As;
    [SerializeField] AudioSource As1;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Cutscene"))
        {
            PlayerPrefs.SetInt("Cutscene", 0);
            As.Play();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.gameObject.SetActive(false);
            As.Pause();
            As1.Play();
        }
        //Debug.Log("is this still running? "+Time.time);
    }
}
