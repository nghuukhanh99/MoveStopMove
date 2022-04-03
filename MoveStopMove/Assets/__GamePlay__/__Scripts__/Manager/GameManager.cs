using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<CharacterManager> _listCharacter = new List<CharacterManager>();

    public bool isGameActive;

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
