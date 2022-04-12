using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<CharacterManager> _listCharacter = new List<CharacterManager>();

    public bool isGameActive;

    public bool isWin;

    public bool isLose;

    public CinemachineVirtualCamera cameraOnMenu;

    public CinemachineVirtualCamera cameraOnShop;

    public int Coins;

    public int enemyCount = 15;

    private void OnEnable()
    {
        CameraSwitcher.Register(cameraOnMenu);

        CameraSwitcher.Register(cameraOnShop);

        CameraSwitcher.SwitchCamera(cameraOnShop);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(cameraOnMenu);

        CameraSwitcher.Unregister(cameraOnShop);

        CameraSwitcher.SwitchCamera(cameraOnShop);
    }

    private void Awake()
    {
        InitializeSingleton();

        isGameActive = false;


    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
}
