using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauceMenuManager : MonoBehaviour
{
    [SerializeField] GameObject PauceMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (!PauceMenu) {
            if (!PauceMenu) Destroy(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauceMenu.SetActive(true);
            Time.timeScale = 0.0f;        }
    }
    public void ResumeButton()
    {
        PauceMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
