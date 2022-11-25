using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }
}
