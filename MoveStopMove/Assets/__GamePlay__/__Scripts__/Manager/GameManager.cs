using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static CharacterManager instance;

    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<CharacterManager>();
            }

            return instance;
        }
    }

}
