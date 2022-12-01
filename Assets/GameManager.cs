using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager TheGM;
    [SerializeField] public PlayerStatManager PlayerStatManager;
    [SerializeField] public GameSceneManager gameSceneManager;
    [SerializeField] Transform EndGameUITran;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (TheGM)
        {
            Destroy(this);
        }
        TheGM = this;
        if (!PlayerStatManager) PlayerStatManager = GetComponent<PlayerStatManager>();
        player.GetComponent<PlayerProjectileSpawner>().AddiStrength = PlayerStatManager.AddiStrength;
        player.GetComponent<PlayerProjectileSpawner>().AddiAttackSpeed = PlayerStatManager.AddiAttackSpeed;
        player.GetComponent<CharacterMovement>().AddiSpeed = PlayerStatManager.AddiSpeed;
    }
    public void SavePlayerStat()
    {
        PlayerStatManager.Save();
    }
    public void EndGame()
    {
        SavePlayerStat();
        //give some chart for the game stats
        EndGameUITran.gameObject.SetActive(true);
        //then on the UI have button for back to menu;
    }
    public void Retry()
    {
        PlayerStatManager.ResetStat();
        gameSceneManager.ReloadScene();
    }
}
