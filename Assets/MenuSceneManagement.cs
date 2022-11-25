using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManagement : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OpetionMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OptionButton()
    {
        MainMenu.SetActive(false);
        OpetionMenu.SetActive(true);
    }
    public void BackButton()
    {
        MainMenu.SetActive(true);
        OpetionMenu.SetActive(false);
    }
}