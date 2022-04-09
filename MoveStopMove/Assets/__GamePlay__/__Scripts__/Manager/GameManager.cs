using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;


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

    public TextMeshProUGUI CoinsText;

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

    public void Start()
    {
        Coins = PlayerPrefs.GetInt("Coins");

        CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void Update()
    {
        CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
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
