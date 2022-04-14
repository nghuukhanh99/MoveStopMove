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

    [HideInInspector] public const string prefsCoinsTag = "Coins";

    public CinemachineVirtualCamera cameraOnMenu;

    public CinemachineVirtualCamera cameraOnShop;

    public int Coins;

    public int EnemyCount;

    public int TotalAlive;
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

        Coins = PlayerPrefs.GetInt(prefsCoinsTag);
    }
    private void Update()
    {
        GUIManager.Instance.CoinsText.text = Coins.ToString();

        SaveCoins();
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

    public void AddCoins(int CoinsToAdd)
    {
        Coins += CoinsToAdd;
    }

    public void DeleteKey()
    {
        PlayerPrefs.DeleteKey(prefsCoinsTag);

        PlayerPrefs.DeleteKey("BuyValue");

        PlayerPrefs.DeleteKey("ItemsId");

        PlayerPrefs.DeleteKey("DisplayValue");

        Coins = 0;

        PlayerPrefs.SetInt(prefsCoinsTag, Coins);

        GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(prefsCoinsTag).ToString();
    }

    public void SaveCoins()
    {
        PlayerPrefs.SetInt(prefsCoinsTag, Coins);
    }


}
