using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManagement : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject OptionMenu;
    [SerializeField] GameObject CreditMenu;
    [SerializeField] GameObject UpgradeMenu;
    [SerializeField] GameObject CutScene;
    [SerializeField] AudioSource As;
    [SerializeField] AudioSource As1;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionButton()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void BackButton()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        CreditMenu.SetActive(false);
        UpgradeMenu.SetActive(false);
    }
    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        CreditMenu.SetActive(true);
    }
    public void UpgradesButton()
    {
        MainMenu.SetActive(false);
        UpgradeMenu.SetActive(true);
    }
    public void CutSceneButton()
    {
        CutScene.SetActive(true);
        As.Play();
        As1.Pause();
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}